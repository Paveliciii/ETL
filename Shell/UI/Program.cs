namespace Shell.UI
{
    using AT.Toolbox;
    using ERMS.Core.Common;
    using ERMS.Core.DAL;
    using ERMS.Core.DbMould;
    using ERMS.UI;
    using GUOP;
    using log4net;
    using Shell.UI.Properties;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using TransportModel;

    internal static class Program
    {
        private static ILog Log;
        private const string ConfigFileName = "ndtm.config";

        [STAThread]
        private static void Main()
        {
            AppInstance.InitializeLogging(Resources.Log4netConfig, null);
            Log = LogManager.GetLogger(typeof(Program).Name);
            string pluginsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PlugIns");
            if (!Directory.Exists(pluginsDir))
            {
                Directory.CreateDirectory(pluginsDir);
            }

            foreach (string str in Directory.GetFiles(pluginsDir, "*.dll"))
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(str));
                if (File.Exists(path))
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception exception)
                    {
                        Log.Error("Main(): Exception ", exception);
                    }
                }
            }
            AppInstance.LoadPlugins = true;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // Global exception handlers to catch unhandled exceptions from WinForms message loop
            Application.ThreadException += (sender, e) =>
            {
                Log.Error("Unhandled thread exception", e.Exception);
                // Prevent application crash on settings save error
                MessageBox.Show(
                    "Ошибка при сохранении настроек:\n" + e.Exception.Message,
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Log.Error("Fatal unhandled exception", e.ExceptionObject as Exception);
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ensure ndtm.config exists before creating the ConfigFileFinder.
            // If ConfigFileFinder is created before the file exists it may scan and record a null BasePath.
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
                Log.InfoFormat("BaseDirectory: {0}", AppDomain.CurrentDomain.BaseDirectory);
                Log.InfoFormat("configPath: {0}", configPath);
                Log.InfoFormat("File exists: {0}", File.Exists(configPath));
                if (!File.Exists(configPath))
                {
                    string settingsXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");
                    if (File.Exists(settingsXml))
                    {
                        File.Copy(settingsXml, configPath);
                        Log.InfoFormat("Copied settings.xml to: {0}", configPath);
                    }
                    else
                    {
                        File.WriteAllText(configPath, "<CONFIG></CONFIG>");
                        Log.InfoFormat("Created minimal ndtm.config at: {0}", configPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Failed to ensure ndtm.config exists", ex);
            }

            AppInstance.ConfigFileFinder = CreateSafeConfigFileFinder();
            RecordManager.Service = new RecordManagementService();
            FileEntityDescriptionSource.ColumnListSources.Add(new EntityInfoCoulmnListSource(GUOPContext.DataSourceName));
            string fieldDescriptionFile = Shell.UI.Properties.Settings.Default.FieldDescription;
            string fieldDescriptionPath = null;
            try
            {
                if (Path.IsPathRooted(fieldDescriptionFile))
                {
                    fieldDescriptionPath = fieldDescriptionFile;
                }
                else
                {
                    // First, check application base directory (output directory)
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string candidate = Path.Combine(baseDir, fieldDescriptionFile);
                    if (File.Exists(candidate))
                        fieldDescriptionPath = candidate;

                    // If not found, walk up a few directory levels to locate the source file (e.g. ../../database.ed when running from bin/Debug)
                    if (fieldDescriptionPath == null)
                    {
                        string up = baseDir;
                        for (int i = 0; i < 6; i++)
                        {
                            up = Path.GetFullPath(Path.Combine(up, ".."));
                            candidate = Path.Combine(up, fieldDescriptionFile);
                            if (File.Exists(candidate))
                            {
                                fieldDescriptionPath = candidate;
                                break;
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(fieldDescriptionPath) && File.Exists(fieldDescriptionPath))
                {
                    try
                    {
                        FileEntityDescriptionSource.Fields[GUOPContext.DataSourceName] = EntityDescriptionContainer.LoadFromFile(fieldDescriptionPath);
                        Log.InfoFormat("Loaded field description from: {0}", fieldDescriptionPath);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Failed to load field description file", ex);
                    }
                }
                else
                {
                    Log.WarnFormat("Field description file not found: {0}. Continuing without it.", fieldDescriptionFile);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error while resolving field description file path", ex);
            }
            FormFactory.Customizations[typeof(VisumDatabase)] = new VisumDatabaseFormFactory();
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PlugIns")))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PlugIns"));
            }
            LookupContainer.Setup<ISqlFormService>(() => new ShellSqlFormService(), true);
            AppWrapper.AddSectionType<ETLSettings>();
            AppWrapper.AddSectionType<ETLShellSettings>();
            AppWrapper.SplashScreen = "Splash.jpg";
            
            try
            {
                AppWrapper.Run<MainForm>(true);
            }
            catch (Exception ex)
            {
                Log.Error("AppWrapper.Run(requireInit=true) failed; retrying without initialization.", ex);
                try
                {
                    AppWrapper.Run<MainForm>(false);
                }
                catch (Exception inner)
                {
                    Log.Error("AppWrapper.Run(requireInit=false) also failed.", inner);
                    throw;
                }
            }
        }

        public static ETLShellSettings Preferences =>
            AppManager.Configurator.GetSection<ETLShellSettings>();

        private static void LogConfigFinderBasePath(ConfigFileFinder finder)
        {
            try
            {
                var basePathProperty = typeof(ConfigFileFinder).GetProperty("BasePath");
                if (basePathProperty != null)
                {
                    object basePath = basePathProperty.GetValue(finder, null);
                    Log.InfoFormat("ConfigFileFinder.BasePath: {0}", basePath ?? "<null>");
                }
                else
                {
                    Log.Warn("ConfigFileFinder.BasePath property not found.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("Failed to read ConfigFileFinder.BasePath", ex);
            }
        }

        private static ConfigFileFinder CreateSafeConfigFileFinder()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string currentDir = Environment.CurrentDirectory;
            string startupPath = Application.StartupPath;
            string[] lookupPaths = new[] { baseDir, currentDir, startupPath };
            var finder = new ConfigFileFinder(lookupPaths, ConfigFileName);

            Log.InfoFormat("ConfigFileFinder lookup paths: {0}", string.Join("; ", lookupPaths));
            LogConfigFinderBasePath(finder);

            try
            {
                // Force finder initialization early so Path.Combine does not fail later during settings save.
                string outputPath = finder.OutputConfigFilePath;
                Log.InfoFormat("ConfigFileFinder.OutputConfigFilePath: {0}", outputPath);
            }
            catch (Exception ex)
            {
                Log.Error("ConfigFileFinder failed during initialization. Creating local fallback config.", ex);

                string fallbackDirectory = string.IsNullOrWhiteSpace(baseDir)
                    ? Directory.GetCurrentDirectory()
                    : baseDir;
                string fallbackPath = Path.Combine(fallbackDirectory, ConfigFileName);
                if (!File.Exists(fallbackPath))
                {
                    File.WriteAllText(fallbackPath, "<CONFIG></CONFIG>");
                }

                finder = new ConfigFileFinder(new[] { fallbackDirectory }, ConfigFileName);
            }

            return finder;
        }
    }
}
