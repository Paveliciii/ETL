namespace Shell.UI.ScenarioDOM
{
    using AT.ETL;
    using AT.Toolbox.Misc;
    using Shell.UI.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class RunScenarioWork : IBackgroundWork, INotifyPropertyChanged
    {
        private readonly DataScenario m_scenario;
        private readonly IDataSourceInitializer m_initializer;

        public event PropertyChangedEventHandler PropertyChanged;

        public RunScenarioWork(DataScenario scenario, IDataSourceInitializer initializer)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException("scenario");
            }
            this.m_scenario = scenario;
            this.m_initializer = initializer;
        }

        public void Run(BackgroundWorker worker)
        {
            if (this.m_initializer != null)
            {
                this.m_initializer.InitDataSource(this.m_scenario.Source);
                if (this.m_scenario.Source != this.m_scenario.Destination)
                {
                    this.m_initializer.InitDataSource(this.m_scenario.Destination);
                }
            }
            this.m_scenario.Execute(worker);
        }

        public bool CloseOnFinish =>
            true;

        public bool IsMarquee =>
            false;

        public bool CanCancel =>
            true;

        public Bitmap Icon =>
            Resources.Transform_48;

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(this.m_scenario.Description))
                {
                    return this.m_scenario.Description;
                }
                return this.m_scenario.ToString();
            }
        }

        public float Weight =>
            1f;

        public object Result =>
            null;
    }
}

