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
    /// Interaction logic for GanzKörperTrainingsFenster.xaml
    /// </summary>
    public partial class GanzKörperTrainingsFenster : Window
    {
        TimerDaten timerDaten = new TimerDaten();
        public Session einheiten;
        Session session = new Session();
        public static HauptprogrammTimer timer;
        List<bool> validList;

        private static readonly Serilog.ILogger logger = LoggerClass.logger;

        public GanzKörperTrainingsFenster(Session einheiten)
        {
            InitializeComponent();
            this.einheiten = einheiten;
            foreach (var item in einheiten.Einheiten)
            {
                uebungListBox.Items.Add(item);
                session.Einheiten.Add(item);
            }
            logger.Information("GanzKörperTrainingsFenster initialisiert");
        }

        private void infoButtonPushUps(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie legen sich zunächst flach mit dem Bauch auf den Boden. Stützen Sie sich anschließend auf Ihren Händen und Zehen ab. Nun senken Sie sich wieder und wiederholen diese Übung. ");
            logger.Information("Push-Ups Info gezeigt");
        }

        private void infoButtonSitUps(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie legen sich bei dieser Übung mit dem Rücken auf dem Boden und halten bei dieser Übung Ihre Füße aufgestellt. Schließlich bewegen Sie Ihren Oberkörper langsam nach oben.  ");
            logger.Information("Sit-Ups Info gezeigt");
        }

        private void infoButtonSquats(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Man steht aufrecht und beugt dann die Knie, um in die Hocke zu gehen. " +
            "Dabei wird der Rücken nicht gerundet oder überstreckt. Das erreicht man, " +
            "indem man die Hüfte beugt und den Oberkörper nach vorne neigt. " +
            "Von der Hocke aus geht man wieder gerade nach oben in die Ausgangslage");
            logger.Information("Squats Info gezeigt");
        }

        private void infoButtonButterfly(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie setzen sich aufrecht auf einem Gerät und bewegen das Gewicht, indem Sie Ihre gespreizten Arme vor Ihrem Oberkörper zusammendrücken .");
            logger.Information("Butterfly Info gezeigt");
        }

        private void infoButtonBulgarianSplitsSquats(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Bei dieser Übung stellst du eines deiner Beine auf eine Bank und gehst mit dem anderen Bein langsam nach in die Knie");
            logger.Information("Bulgarian-Splits-Squats Info gezeigt");
        }

        private void infoButtonCrunches(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie beginnen mit einer liegenden Ausgangsposition und heben den Oberkörper mit leichter Krümmung an. ");
            logger.Information("Crunches Info gezeigt");
        }

        private void zeigeDataFenster(string nachricht)
        {
            DatenFenster daten = new DatenFenster(einheiten, uebungListBox);
            daten.einheitenName.Text = nachricht;
            daten.ShowDialog();
            // uebungListBox.Items.Add(daten.nutzer);
            logger.Information("Datenfenster geöffnet");
        }

        private void addButtonPushUps(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Push-Ups");
            logger.Information("Push-Ups Button geklickt");
        }

        private void addButtonSitUps(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Sit-Ups");
            logger.Information("Sit-Ups Button geklickt");
        }
        private void addButtonSquats(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Squats");
            logger.Information("Squats Button geklickt");
        }

        private void addButtonButterfly(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Butterfly");
            logger.Information("Butterfly Button geklickt");
        }
        private void addButtonBulgarianSplitsSquats(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Bulgarian-Splits-Squats");
            logger.Information("Bulgarian-Splits-Squats Button geklickt");
        }

        private void addButtonCrunches(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Crunches");
            logger.Information("Crunches Button geklickt");
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
                Console.WriteLine("Platzhalter");
                logger.Error("Fehler beim Verschieben des Fensters: " + ex.Message);
            }
        }

        private void fensterSchließen(object sender, MouseButtonEventArgs e)
        {
            einheiten.Einheiten.Clear();
            foreach (nutzerEingabe item in uebungListBox.Items)
            {
                einheiten.Einheiten.Add(item);
            }
            this.Close();
            logger.Information("Fenster geschlossen");
        }

        private void fensterMinimieren(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
            logger.Information("Fenster minimiert");
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            einheiten.Einheiten.Clear();
            foreach (nutzerEingabe item in uebungListBox.Items)
            {
                einheiten.Einheiten.Add(item);
            }
            this.Close();
            logger.Information("Abbrechen Button geklickt");
        }

        private void buttonLoeschen_Click(object sender, RoutedEventArgs e)
        {
            if (uebungListBox.SelectedItem != null)
            {
                uebungListBox.Items.Remove(uebungListBox.SelectedItem);
                logger.Information("Eintrag in ListBox gelöscht");
            }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (uebungListBox.Items.Count == 0)
                {
                    MessageBox.Show("Bitte tragen Sie Übungen ein. ");
                }

                else
                {
                    foreach (var item in uebungListBox.Items)
                    {
                        timerDaten.timerDaten.Add((nutzerEingabe)item);
                    }

                    timer = new HauptprogrammTimer(timerDaten.timerDaten, validList);
                    timer.derzeitigeGrundEinheitTextBox.Text = "Ganzkörpertraining";
                    einheiten.Einheiten.Clear();
                    foreach (nutzerEingabe item in uebungListBox.Items)
                    {
                        einheiten.Einheiten.Add(item);
                    }
                    this.Close();
                    timer.ShowDialog();
                    logger.Information("Timer gestartet");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fehler beim Klicken des OK-Buttons.");

            }


        }
    }
}
