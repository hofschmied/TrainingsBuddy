using LiveCharts.Wpf;
using LiveCharts;
using Serilog;
using System;
using System.Windows;

namespace Trainingscoach_Projekt
{
    /// <summary>
    /// Interaction logic for Statistik.xaml
    /// </summary>
    public partial class Statistik : Window
    {
        private static readonly Serilog.ILogger logger = LoggerClass.logger;

        public HauptprogrammTimer timerArm = ArmTrainingsFenster.timer;
        public HauptprogrammTimer timerBauch = BauchTrainingsFenster.timer;

        public Statistik()
        {
            InitializeComponent();

            double armdauer = 0;
            double beindauer = 0;
            double bauchdauer = 0;
            double brustdauer = 0;
            double rueckendauer = 0;
            double ganzkörperdauer = 0;
            double cardiodauer = 0;

            if (timerArm != null && timerArm.derzeitigeGrundEinheitTextBox != null)
            {
                if (timerArm.derzeitigeGrundEinheitTextBox.Text == "Armtraining")
                {
                    foreach (double zahl in timerArm.dauerListe)
                    {
                        armdauer += zahl;
                    }
                }
            }

            if (timerBauch != null && timerBauch.derzeitigeGrundEinheitTextBox != null)
            {
                if (timerBauch.derzeitigeGrundEinheitTextBox.Text == "Bauchtraining")
                {
                    foreach (double zahl in timerBauch.dauerListe)
                    {
                        bauchdauer += zahl;
                    }
                }
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Trainingsdauer",
                    Values = new ChartValues<double> { armdauer, beindauer, bauchdauer, brustdauer, rueckendauer, ganzkörperdauer, cardiodauer },
                }
            };

            Labels = new[] { "Armtraining", "Beintraining", "Bauchtraining", "Brusttraining", "Rückentraining", "Ganzkörpertraining", "Cardiotraining" };
            Formatter = value => value.ToString("N");

            this.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF383838"));
            DataContext = this;

            logger.Information("Statistik Fenster initialisiert");
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            logger.Information("Statistik Fenster geschlossen");
        }
    }
}
