using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Trainingscoach_Projekt
{
    /// <summary>
    /// Interaction logic for Statistik.xaml
    /// </summary>
    public partial class Statistik : Window
    {
        public HauptprogrammTimer timer = ArmTrainingsFenster.timer;
        public Statistik()
        {
            InitializeComponent();

            double armdauer = 0;

            foreach (double zahl in timer.dauerListe)
            {
                armdauer += zahl;
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Trainingsdauer",
                    Values = new ChartValues<double> { armdauer, 0, 0, 0, 0, 0, 0  },
                    
                }
            };
            
            Labels = new[] { "Armtraining", "Beintraining", "Bauchtraining", "Brusttraining", "Rückentraining", "Ganzkörpertraining", "Cardiotraining" };
            Formatter = value => value.ToString("N");
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF383838"));
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

    }
}

