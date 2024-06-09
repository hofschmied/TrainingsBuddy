using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.IO;
using System.Text.Json;

namespace Trainingscoach_Projekt
{
    public partial class HauptprogrammTimer : Window
    {
        private DispatcherTimer timer;
        private TimeSpan time;
        private List<nutzerEingabe> timerDaten = new List<nutzerEingabe>();
        public List<double> dauerListe = new List<double>();
        private MediaPlayer pausenMusikPlayer;
        private MediaPlayer countDownPlayer;
        private MediaPlayer taskErledigtPlayer;
        private MediaPlayer kleinePausePlayer;
        private bool pause = false;
        private bool grossepause = false;
        private int naechsteSets;
        public int anzahlsets = 1;
        private QuestFenster quest;
        private List<string> erledigteUebungenList = new List<string>();
        public List<bool> validList;
        int count = 0;
        private static readonly Serilog.ILogger logger = LoggerClass.logger;

        public HauptprogrammTimer(List<nutzerEingabe> timerDaten, List<bool> validList)
        {
            InitializeComponent();
            this.validList = validList;
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
            dauerListHinzu();
            this.Closing += HauptprogrammTimer_Closing;
            logger.Information("HauptprogrammTimer initialisiert");
        }

        public void dauerListHinzu()
        {
            for (int i = 0; i < timerDaten.Count; i++)
            {
                int anzahl = timerDaten[i].anzahlSets;
                anzahlsets *= anzahl;

                double dauer = timerDaten[i].dauer * anzahlsets;
                dauerListe.Add(dauer);
                logger.Information("Items wurden der Liste für die Statistik hinzugefügt");
            }
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
                logger.Information("Felder befüllt");
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
                            erledigteUebungen.Items.Add(derzeitigeUebungen.Items[count]);
                            ueberpruefeQuests();

                            timerDaten.Remove(timerDaten[0]);

                            if (timerDaten.Count > 0)
                            {
                                grossepause = true;
                                verdientePause();
                            }
                            else
                            {
                                TrainingBeendetFenster trainingBeendet = new TrainingBeendetFenster();
                                this.Close();
                                trainingBeendet.ShowDialog();
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
                logger.Information("Training gestartet");
            }
            catch (FormatException)
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl ein.");
                logger.Error("Ungültige Zahl eingegeben");
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
            logger.Information("Verdiente Pause gestartet");
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
            logger.Information("Kleine Verschnaufpause gestartet");
        }

        private void startNaechstesSet()
        {
            derzeitigeTrainingEinheitTextBox.Text = timerDaten[0].einheitenName;
            time = TimeSpan.FromMinutes(Convert.ToDouble(laengeEinheit.Text));
            TimerTextBlock.Text = time.ToString(@"mm\:ss");
            timer.Start();
            logger.Information("Starte nächstes Set");
        }

        private void taskErledigtSound()
        {
            Uri uri = new Uri("src/sounds/taskFertig.mp3", UriKind.Relative);
            taskErledigtPlayer.Open(uri);
            taskErledigtPlayer.Play();
            logger.Information("Aufgabe erledigt-Sound abgespielt");
        }

        private void countDownSound()
        {
            Uri uri = new Uri("src/sounds/3secs.mp3", UriKind.Relative);
            countDownPlayer.Open(uri);
            countDownPlayer.Play();
            logger.Information("Countdown-Sound abgespielt");
        }

        private void pausenMusik()
        {
            Uri uri = new Uri("src/sounds/pausenMusik.mp3", UriKind.Relative);
            pausenMusikPlayer.Open(uri);
            pausenMusikPlayer.Play();
            logger.Information("Pausenmusik gestartet");
        }

        private void HauptprogrammTimer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            musikStoppen();
            timer.Tick -= timerJaDerTicktSchoen;
            logger.Information("HauptprogrammTimer geschlossen");
        }

        private void musikStoppen()
        {
            pausenMusikPlayer.Stop();
            countDownPlayer.Stop();
            taskErledigtPlayer.Stop();
            kleinePausePlayer.Stop();
            logger.Information("Musik gestoppt");
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            musikStoppen();
            logger.Information("Timer gestoppt");
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
                logger.Error($"Fehler beim Öffnen des Standard-Browsers: {ex.Message}");
            }
        }
        private void ueberpruefeQuests()
        {
            if (validList != null)
            {
                foreach (nutzerEingabe item in erledigteUebungen.Items)
                {
                    if (item.einheitenName == "Kickbacks" && item.anzahlSets >= 5 && derzeitigeGrundEinheitTextBox.Text == "Armtraining")
                    {
                        MessageBox.Show("Glückwunsch! Aufgabe abgeschlossen: erledige 5 Sets Kickbacks");
                        validList[0] = true;
                    }

                    if (item.einheitenName == "SZ-Curls" && item.anzahlSets >= 20 && derzeitigeGrundEinheitTextBox.Text == "Armtraining")
                    {
                        MessageBox.Show("Glückwunsch! Aufgabe abgeschlossen: erledige 20 Sets SZ-Curls");
                        validList[1] = true;
                    }

                    if (item.anzahlSets * item.dauer >= 15 && derzeitigeGrundEinheitTextBox.Text == "Armtraining")
                    {
                        MessageBox.Show("Glückwunsch! Aufgabe abgeschlossen: Trainiere 10 Minuten");
                        validList[2] = true;
                    }

                    if (erledigteUebungen.Items.Count >= 2 && derzeitigeGrundEinheitTextBox.Text == "Armtraining")
                    {
                        MessageBox.Show("Glückwunsch! Aufgabe abgeschlossen: erledige 2 Armübungen deiner Wahl");
                        validList[3] = true;
                        logger.Information("Quest überprüft und aktualisiert");
                    }

                    if (item.einheitenName == "Hammercurls" && item.anzahlSets >= 3 && derzeitigeGrundEinheitTextBox.Text == "Armtraining")
                    {
                        MessageBox.Show("Glückwunsch! Aufgabe abgeschlossen: erledige 3 Sets Hammercurls");
                        validList[4] = true;
                        logger.Information("Quest überprüft und aktualisiert");
                    }
                }

                if (quest != null)
                {
                    quest.QuestSpeichern();
                }
                else
                {
                    string filePath = "questStatus.json";
                    string json = JsonSerializer.Serialize(validList);
                    File.WriteAllText(filePath, json);
                    logger.Information("Quest-Zustand direkt aus HauptprogrammTimer gespeichert");
                }
            }
            else
            {
                logger.Error("validList is null");
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
            logger.Information("Fenster geschlossen");
        }

        private void fensterMinimieren(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
            logger.Information("Fenster minimiert");
        }
    }
}
