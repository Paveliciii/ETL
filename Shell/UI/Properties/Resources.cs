namespace Shell.UI.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), CompilerGenerated, DebuggerNonUserCode]
    internal class Resources
    {
        private static System.Resources.ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (ReferenceEquals(resourceMan, null))
                {
                    // Try to resolve the actual base name of the embedded resources in the assembly.
                    var asm = typeof(Resources).Assembly;
                    string expectedBaseName = "Shell.UI.Properties.Resources";
                    string actualBaseName = expectedBaseName;

                    try
                    {
                        foreach (var name in asm.GetManifestResourceNames())
                        {
                            if (name.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
                            {
                                var bn = name.Substring(0, name.Length - ".resources".Length);
                                if (bn.EndsWith(".Properties.Resources", StringComparison.OrdinalIgnoreCase))
                                {
                                    actualBaseName = bn;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        // If anything goes wrong enumerating resources, fall back to the expected base name.
                        actualBaseName = expectedBaseName;
                    }

                    resourceMan = new System.Resources.ResourceManager(actualBaseName, asm);
                }
                return resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get => 
                resourceCulture;
            set => 
                resourceCulture = value;
        }

        internal static string COLUMN_NO_FORMAT =>
            ResourceManager.GetString("COLUMN_NO_FORMAT", resourceCulture);

        internal static string INCORRECT_COLUMN_ACTION =>
            ResourceManager.GetString("INCORRECT_COLUMN_ACTION", resourceCulture);

        internal static string Log4netConfig =>
            ResourceManager.GetString("Log4netConfig", resourceCulture);

        internal static Bitmap Transform_32 =>
            (Bitmap) ResourceManager.GetObject("Transform_32", resourceCulture);

        internal static Bitmap Transform_48 =>
            (Bitmap) ResourceManager.GetObject("Transform_48", resourceCulture);
    }
}

