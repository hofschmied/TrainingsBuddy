using System;
using System.Windows;
using System.Windows.Input;
using Serilog;

namespace Trainingscoach_Projekt
{
    /// <summary>
    /// Interaction logic for TrainingBeendetFenster.xaml
    /// </summary>
    public partial class TrainingBeendetFenster : Window
    {
        private static readonly Serilog.ILogger logger = LoggerClass.logger;

        public TrainingBeendetFenster()
        {
            InitializeComponent();
            logger.Information("TrainingBeendetFenster initialisiert");
        }

        private void Window_MausRunter(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fehler beim Bewegen des Fensters.");
            }
        }

        private void fensterSchließen(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            logger.Information("TrainingBeendetFenster geschlossen");
        }

        private void fensterMinimieren(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonStatistik_Click(object sender, RoutedEventArgs e)
        {
            Statistik statistik = new Statistik();
            this.Close();
            statistik.ShowDialog();
            logger.Information("Statistik geöffnet von TrainingBeendetFenster aus");
        }
    }
}
