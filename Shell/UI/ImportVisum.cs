namespace Shell.UI
{
    using AT.Toolbox.Misc;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class ImportVisum : IBackgroundWork, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Run(BackgroundWorker worker)
        {
        }

        public bool CloseOnFinish =>
            true;

        public bool CanCancel =>
            true;

        public bool IsMarquee =>
            false;

        public object Result =>
            null;

        public Bitmap Icon =>
            null;

        public string Name =>
            "Импорт дорожной сети ..";

        public float Weight =>
            1f;

        public string FileName { get; set; }

        public bool DropBeforeImport { get; set; }
    }
}

