namespace Shell.UI.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"), CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) Synchronized(new Settings()));

        public static Settings Default =>
            defaultInstance;

        [DebuggerNonUserCode, DefaultSettingValue("database.ed"), ApplicationScopedSetting]
        public string FieldDescription =>
            (string) this["FieldDescription"];
    }
}

