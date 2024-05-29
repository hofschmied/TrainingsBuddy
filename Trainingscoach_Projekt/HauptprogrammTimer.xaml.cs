using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trainingscoach_Projekt
{
    public partial class HauptprogrammTimer : Window
    {
        private DispatcherTimer timer;
        private TimeSpan time;
        private List<nutzerEingabe> timerDaten = new List<nutzerEingabe>();

        public HauptprogrammTimer(List<nutzerEingabe> timerDaten)
        {
            InitializeComponent();
            this.timerDaten = timerDaten;
            derzeitigeUebungen.ItemsSource = this.timerDaten;
            felderBefulleLeereSchachteln();
        }

        private void felderBefulleLeereSchachteln()
        {
            if (timerDaten[0] != null)
            {
                nutzerEingabe nutzer = timerDaten[0] as nutzerEingabe;
                derzeitigeTrainingEinheitTextBox.Text = nutzer.einheitenName;
                setsAnzahl.Text = nutzer.anzahlSets.ToString();
                laengeEinheit.Text = nutzer.dauer.ToString();
            }
        }
      
        private void Button_Click_Spotify(object sender, RoutedEventArgs e)
        {
           
        }

                   
        private void Window_MausRunter(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }

        private void fensterSchließen(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void fensterMinimieren(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}