namespace Shell.UI
{
    using ERMS.Core.Common;
    using ERMS.Core.DAL;
    using ERMS.Core.DAL.Sql;
    using System;
    using System.Runtime.CompilerServices;

    public class ETLShellSettings : ConfigurationSection
    {
        public override void ApplySettings()
        {
            if (!string.IsNullOrEmpty(this.GUOPConnectionString) && AppManager.Configurator.GetSection<ETLSettings>().DataSources.ContainsKey("GUOP"))
            {
                int timeout = AppManager.Configurator.GetSection<ETLSettings>().DataSources["GUOP"].Timeout;
                DataSourceInfo sourceInfo = new DataSourceInfo(new SqlRecordBinder("GUOP", this.GUOPConnectionString));
                if (timeout > 0)
                {
                    sourceInfo.CommandTimeout = timeout;
                }
                RecordManager.DataSources.Add(sourceInfo, false);
            }
        }

        public string GUOPConnectionString { get; set; }
    }
}

