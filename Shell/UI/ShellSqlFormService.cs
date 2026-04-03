namespace Shell.UI
{
    using AT.ETL;
    using Shell.UI.Adapters;
    using System;
    using System.Windows.Forms;

    internal class ShellSqlFormService : ISqlFormService
    {
        public bool ShowScenarioForm(object owner, string sourceName, string destinationName, ETLConnectionPair pair)
        {
            using (RunScenarioForm form = new RunScenarioForm())
            {
                form.Source = sourceName;
                form.Destination = destinationName;
                form.ConnectionPair = pair;
                return (form.ShowDialog(owner as IWin32Window) == DialogResult.OK);
            }
        }

        public bool ShowSqlServerForm(ConnectionEntry entry)
        {
            using (SqlConnectionForm form = new SqlConnectionForm())
            {
                if (form.ShowDialog(entry.Caller as IWin32Window) == DialogResult.OK)
                {
                    entry.ConnectionString = form.ConnectionString;
                    return true;
                }
            }
            return false;
        }
    }
}

