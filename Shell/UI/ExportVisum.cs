namespace Shell.UI
{
    using AT.ETL;
    using AT.Toolbox.Misc;
    using ERMS.Core.Common;
    using log4net;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    internal class ExportVisum : IBackgroundWork, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Run(BackgroundWorker worker)
        {
            IInfoView infoView = AppManager.InfoView;
            try
            {
                AppManager.InfoView = new MessageToLog();
                // Ensure no-op subscription if needed
                // this.PropertyChanged += delegate { };
                if (this.SourceFile != this.DestinationFile)
                {
                    if (File.Exists(this.DestinationFile))
                    {
                        File.Delete(this.DestinationFile);
                    }
                    File.Copy(this.SourceFile, this.DestinationFile);
                }
                DataContractSerializer serializer = new DataContractSerializer(typeof(DataScenario));
                using (FileStream stream = new FileStream(this.ScenarioPath, FileMode.Open))
                {
                    (serializer.ReadObject(stream) as DataScenario).Execute(worker);
                }
            }
            finally
            {
                AppManager.InfoView = infoView;
            }
        }

        public bool CloseOnFinish =>
            true;

        public bool IsMarquee =>
            false;

        public bool CanCancel =>
            true;

        public Bitmap Icon =>
            null;

        public string Name =>
            "Экспорт данных в Visum";

        public float Weight =>
            1f;

        public object Result =>
            null;

        public string SourceFile { get; set; }

        public string DestinationFile { get; set; }

        public string ScenarioPath { get; set; }

        private class MessageToLog : IInfoView
        {
            private static readonly ILog Log = LogManager.GetLogger(typeof(ExportVisum.MessageToLog).Name);

            bool IInfoView.Confirm(InfoBuffer buffer) => 
                this.ShowBuffer(buffer, true);

            void IInfoView.ShowBuffer(InfoBuffer buffer)
            {
                this.ShowBuffer(buffer, false);
            }

            void IInfoView.ShowBuffer(string summary, InfoBuffer buffer)
            {
                this.ShowBuffer(buffer, false);
            }

            private bool ShowBuffer(InfoBuffer buffer, bool allowContinue)
            {
                foreach (Info info in buffer)
                {
                    switch (info.Level)
                    {
                        case InfoLevel.Debug:
                            Log.Debug(info.Message);
                            break;

                        case InfoLevel.Info:
                            Log.Info(info.Message);
                            break;

                        case InfoLevel.Warning:
                            Log.Warn(info.Message);
                            break;

                        case InfoLevel.Error:
                            Log.Error(info.Message, info.Details as Exception);
                            break;
                    }
                }
                return allowContinue;
            }
        }
    }
}

