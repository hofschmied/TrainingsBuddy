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
        private MediaPlayer pausenMusikPlayer;
        private MediaPlayer countDownPlayer;
        private MediaPlayer taskErledigtPlayer;
        private MediaPlayer kleinePausePlayer;
        private bool pause = false;
        private bool grossepause = false;
        private int naechsteSets;

        public HauptprogrammTimer(List<nutzerEingabe> timerDaten)
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            this.timerDaten = timerDaten;
            derzeitigeUebungen.ItemsSource = this.timerDaten;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerJaDerTicktSchoen;
            pausenMusikPlayer = new MediaPlayer();
            countDownPlayer = new MediaPlayer();
            taskErledigtPlayer = new MediaPlayer();
            kleinePausePlayer = new MediaPlayer();
            felderBefuelleLeereKartons();
            this.Closing += HauptprogrammTimer_Closing;
        }

        private void felderBefuelleLeereKartons()
        {
            if (timerDaten[0] != null)
            {
                nutzerEingabe nutzer = timerDaten[0] as nutzerEingabe;
                derzeitigeTrainingEinheitTextBox.Text = nutzer.einheitenName;
                setsAnzahl.Text = nutzer.anzahlSets.ToString();
                laengeEinheit.Text = nutzer.dauer.ToString();
                naechsteSets = nutzer.anzahlSets;
            }
        }

        private void timerJaDerTicktSchoen(object sender, EventArgs e)
        {
            if (time > TimeSpan.Zero)
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                TimerTextBlock.Text = time.ToString(@"mm\:ss");
                TimerProgressBar.Value = 100 * (time.TotalSeconds / (pause ? 15 : Convert.ToDouble(laengeEinheit.Text) * 60));

                if (TimerTextBlock.Text == "00:00")
                {
                    timer.Stop();

                    if (pause)
                    {
                        pause = false;
                        startNaechstesSet();
                    }
                    else if (grossepause)
                    {
                        grossepause = false;
                        felderBefuelleLeereKartons();
                        startNaechstesSet();
                    }
                    else
                    {
                        naechsteSets--;
                        setsAnzahl.Text = naechsteSets.ToString();

                        if (naechsteSets > 0)
                        {
                            setsPause();
                        }
                        else
                        {
                            timerDaten.Remove(timerDaten[0]);

                            if (timerDaten.Count > 0)
                            {
                                grossepause = true;
                                verdientePause();
                            }
                            else
                            {
                                TrainingBeendetFenster training = new TrainingBeendetFenster();
                                this.Close();
                                training.ShowDialog();
                            }
                        }
                    }
                }

                if (TimerTextBlock.Text == "00:03")
                {
                    countDownSound();
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
            derzeitigeTrainingEinheitTextBox.Text = "Zeit für eine Pause!";
            setsAnzahl.Text = "Schwing doch gerne dein Tanzbein!";
            laengeEinheit.Text = "5";
            time = TimeSpan.FromSeconds(10);
            TimerTextBlock.Text = time.ToString(@"mm\:ss");
            timer.Start();
            pausenMusik();
        }

        private void setsPause()
        {
            Uri uri = new Uri("src/sounds/kleinePause.mp3", UriKind.Relative);
            kleinePausePlayer.Open(uri);
            kleinePausePlayer.Play();

            derzeitigeTrainingEinheitTextBox.Text = "Kleine Verschnaufpause ";
            time = TimeSpan.FromSeconds(15);
            TimerTextBlock.Text = time.ToString(@"mm\:ss");
            pause = true;
            timer.Start();
        }

        private void startNaechstesSet()
        {
            derzeitigeTrainingEinheitTextBox.Text = timerDaten[0].einheitenName;
            time = TimeSpan.FromMinutes(Convert.ToDouble(laengeEinheit.Text));
            TimerTextBlock.Text = time.ToString(@"mm\:ss");
            timer.Start();
        }

        private void taskErledigtSound()
        {
            Uri uri = new Uri("src/sounds/taskFertig.mp3", UriKind.Relative);
            taskErledigtPlayer.Open(uri);
            taskErledigtPlayer.Play();
        }

        private void countDownSound()
        {
            Uri uri = new Uri("src/sounds/3secs.mp3", UriKind.Relative);
            countDownPlayer.Open(uri);
            countDownPlayer.Play();
        }

        private void pausenMusik()
        {
            Uri uri = new Uri("src/sounds/pausenMusik.mp3", UriKind.Relative);
            pausenMusikPlayer.Open(uri);
            pausenMusikPlayer.Play();
        }

        private void HauptprogrammTimer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            musikStoppen();
            timer.Tick -= timerJaDerTicktSchoen;
        }

        private void musikStoppen()
        {
            pausenMusikPlayer.Stop();
            countDownPlayer.Stop();
            taskErledigtPlayer.Stop();
            kleinePausePlayer.Stop();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            musikStoppen();
        }

        private void Button_Click_Spotify(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c start https://open.spotify.com/playlist/37i9dQZF1DX5FlZmJ3JWL1",
                    CreateNoWindow = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Öffnen des Standard-Browsers: {ex.Message}");
            }
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
