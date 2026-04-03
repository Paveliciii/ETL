namespace Shell.UI
{
    using AT.ETL.DataSources;
    using System;
    using System.ComponentModel;

    public class AddDataSourceWork : DataSourceWork
    {
        public AddDataSourceWork(DataSourceSet set, DataSource ds, string connectionString) : base(set, ds, connectionString)
        {
        }

        public override void Run(BackgroundWorker worker)
        {
            base.PropertyChanged += delegate {
            };
            base.m_set.AddDataSource(base.m_ds, base.m_connection_string, worker);
        }
    }
}

