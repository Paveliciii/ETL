namespace Shell.UI
{
    using AT.ETL.DataSources;
    using AT.Toolbox.Misc;
    using Shell.UI.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public abstract class DataSourceWork : IBackgroundWork, INotifyPropertyChanged
    {
        protected readonly DataSourceSet m_set;
        protected readonly DataSource m_ds;
        protected readonly string m_connection_string;

        public event PropertyChangedEventHandler PropertyChanged;

        public DataSourceWork(DataSourceSet set, DataSource ds, string connectionString)
        {
            if (set == null)
            {
                throw new ArgumentNullException("set");
            }
            if (ds == null)
            {
                throw new ArgumentNullException("ds");
            }
            this.m_set = set;
            this.m_ds = ds;
            this.m_connection_string = connectionString;
        }

        public abstract void Run(BackgroundWorker worker);

        public bool CloseOnFinish =>
            true;

        public bool IsMarquee =>
            false;

        public bool CanCancel =>
            false;

        public Bitmap Icon =>
            Resources.Transform_48;

        public string Name =>
            "Добавление источника данных";

        public float Weight =>
            1f;

        public object Result =>
            null;
    }
}

