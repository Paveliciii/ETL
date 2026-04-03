using System;
using System.Collections.Generic;
using ERMS.Core.Common;

namespace Shell.UI
{
    public class ETLSettingsDataSourceConfig
    {
        public int Timeout { get; set; }
    }

    public class ETLSettings : ConfigurationSection
    {
        public static ETLSettings Preferences { get; } = new ETLSettings();

        public Dictionary<string, ETLSettingsDataSourceConfig> DataSources { get; } = new Dictionary<string, ETLSettingsDataSourceConfig>(StringComparer.OrdinalIgnoreCase);

        public Dictionary<string, AT.ETL.ETLConnectionPair> ScenarioConnections { get; } = new Dictionary<string, AT.ETL.ETLConnectionPair>(StringComparer.OrdinalIgnoreCase);
    }

    public interface ISqlFormService
    {
        bool ShowScenarioForm(object owner, string sourceName, string destinationName, AT.ETL.ETLConnectionPair pair);
        bool ShowSqlServerForm(AT.ETL.ConnectionEntry entry);
    }
}
