namespace Shell.UI
{
    using AT.Toolbox.Misc;
    using ERMS.Core.DAL;
    using ERMS.Map;
    using RoadNetwork;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;

    internal class CorrectCoordinatesWork : IBackgroundWork, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Run(BackgroundWorker worker)
        {
            string[] strArray = File.ReadAllLines(this.FileName);
            int length = strArray.Length;
            for (int i = 0; i < length; i++)
            {
                string[] strArray2 = strArray[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    int number = int.Parse(strArray2[1]);
                    double num3 = double.Parse(strArray2[2]);
                    double num4 = double.Parse(strArray2[3]);
                    SinglePhaseCollection<Node> list = new SinglePhaseCollection<Node>();
                    list.DataBind<Node>(x => x.Number == number);
                    if ((list != null) && (list.Count > 0))
                    {
                        GeoPoint point = new GeoPoint(list[0].ID);
                        if ((point != null) && point._IsDataBound)
                        {
                            point.X = num3;
                            point.Y = num4;
                            point.Update();
                        }
                    }
                }
                catch (Exception)
                {
                }
                worker.ReportProgress((i * 100) / length);
            }
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
            "Корректировка координат";

        public float Weight =>
            1f;

        public string FileName { get; set; }
    }
}

