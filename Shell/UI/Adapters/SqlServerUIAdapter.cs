namespace Shell.UI.Adapters
{
    using AT.ETL;
    using ERMS.Core.DAL;
    using ERMS.Core.DAL.Sql;
    using System;
    using System.Windows.Forms;

    public class SqlServerUIAdapter : IETLUIAdapter
    {
        public IRecordBinder GetRecordBinder(string dataSourceName, string connectionString) => 
            new SqlRecordBinder(dataSourceName, connectionString);

        public bool RunSetupDialog(ConnectionEntry entry)
        {
            SqlConnectionForm form = new SqlConnectionForm {
                ConnectionString = entry.ConnectionString
            };
            if (form.ShowDialog(entry.Caller as IWin32Window) == DialogResult.OK)
            {
                entry.ConnectionString = form.ConnectionString;
                return true;
            }
            return false;
        }

        public override string ToString() => 
            "MS Sql Server";
    }
}

