namespace Shell.UI.Adapters
{
    using AT.ETL;
    using ERMS.Core.DAL;
    using ERMS.Core.DAL.OleDb;
    using System;
    using System.Windows.Forms;

    public class MicrosoftAccessUIAdapter : IETLUIAdapter
    {
        private const string ProviderPrefix = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";

        public IRecordBinder GetRecordBinder(string dataSourceName, string connectionString) => 
            new AccessRecordBinder(dataSourceName, connectionString);

        public bool RunSetupDialog(ConnectionEntry entry)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Microsoft Access databases|*.mdb"
            };
            if (!string.IsNullOrEmpty(entry.ConnectionString))
            {
                dialog.FileName = entry.ConnectionString.Replace("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", "");
            }
            if (dialog.ShowDialog(entry.Caller as IWin32Window) == DialogResult.OK)
            {
                entry.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dialog.FileName;
                return true;
            }
            return false;
        }

        public override string ToString() => 
            "MS Access";
    }
}

