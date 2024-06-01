using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

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
            timer = new DispatcherTimer();
            this.timerDaten = timerDaten;
            derzeitigeUebungen.ItemsSource = this.timerDaten;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerJaDerTicktSchoen;
            felderBefuelleLeereKartons();
        }

        private void felderBefuelleLeereKartons()
        {
            if (timerDaten[0] != null)
            {
                nutzerEingabe nutzer = timerDaten[0] as nutzerEingabe;
                derzeitigeTrainingEinheitTextBox.Text = nutzer.einheitenName;
                setsAnzahl.Text = nutzer.anzahlSets.ToString();
                laengeEinheit.Text = nutzer.dauer.ToString();
            }
        }

        private void timerJaDerTicktSchoen(object sender, EventArgs e)
        {
            if (time > TimeSpan.Zero)
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                TimerTextBlock.Text = time.ToString(@"mm\:ss");
                TimerProgressBar.Value = 100 * (time.TotalSeconds / (Convert.ToDouble(laengeEinheit.Text) * 60));

                if (TimerTextBlock.Text == "00:00")
                {
                    int neuSetsAnzahl = Convert.ToInt32(setsAnzahl.Text) - 1;
                    setsAnzahl.Text = neuSetsAnzahl.ToString();
                    double zeit = Convert.ToDouble(laengeEinheit.Text);
                    taskErledigtSound();
                    time = TimeSpan.FromMinutes(zeit);
                    TimerTextBlock.Text = time.ToString(@"mm\:ss");
                    timer.Start();

                    if (neuSetsAnzahl == 0)
                    {
                        timer.Stop();
                        verdientePause();
                    }
                }
            }
            else
            {
                timer.Stop();
                TimerTextBlock.Text = "00:00";
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double zeit = Convert.ToDouble(laengeEinheit.Text);
                time = TimeSpan.FromMinutes(zeit);
                TimerTextBlock.Text = time.ToString(@"mm\:ss");
                timer.Start();
            }
            catch (FormatException)
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl ein.");
            }
        }

        private void verdientePause()
        {
            derzeitigeTrainingEinheitTextBox.Text = "Gönn dir eine kleine Pause!";
            setsAnzahl.Text = "Sorg dich nicht um Sets, genieß deine Pause";
            laengeEinheit.Text = "5";
            time = TimeSpan.FromMinutes(5);
            TimerTextBlock.Text = time.ToString(@"mm\:ss");
            timer.Start();
        }

        private void taskErledigtSound()
        {
            Uri uri = new Uri(@"C:\Users\david\Documents\Schule\POS\Trainingscoach_Projekt\Trainingscoach_Projekt\src\sounds\taskFertig.mp3");
            var hoerKasette = new MediaPlayer();
            hoerKasette.Open(uri);
            hoerKasette.Play();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Button_Click_Spotify(object sender, RoutedEventArgs e)
        {
         
        }

        private void Window_MausRunter(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
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
    }
}
