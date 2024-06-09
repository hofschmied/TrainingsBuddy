using Newtonsoft.Json;
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
using Newtonsoft.Json;

namespace Trainingscoach_Projekt
{
    /// <summary>
    /// Interaction logic for ArmTrainingsFenster.xaml
    /// </summary>
    public partial class ArmTrainingsFenster : Window
    {

        private static readonly Serilog.ILogger logger = LoggerClass.logger;

        TimerDaten timerDaten = new TimerDaten();
        public Session einheiten;
        public static HauptprogrammTimer timer;
        Session session = new Session();
        public List<bool> validList;


        public ArmTrainingsFenster(Session einheiten, List<bool> validList)
        {
            InitializeComponent();
            this.einheiten = einheiten;
            this.validList = validList;
            foreach (var item in einheiten.Einheiten)
            {
                uebungListBox.Items.Add(item);
                session.Einheiten.Add(item);
            }
            logger.Information($"ArmTrainingsFenster initialisiert");
        }

        private void Window_MausRunter(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if(e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Platzhalter");
                logger.Error(ex, "Fehler beim Bewegen des Fensters.");
            }
        }

        private void fensterSchließen(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
                einheiten.Einheiten.Clear();
                foreach (nutzerEingabe item in uebungListBox.Items)
                {
                    einheiten.Einheiten.Add(item);
                }
            }
            catch (NullReferenceException ex)
            {
                logger.Error(ex, "Fehler beim Schließen des Fensters.");
            }
        }

        private void fensterMinimieren(object sender, MouseButtonEventArgs e)
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fehler beim Minimieren des Fensters.");
            }
        }

        private void InfoButtonHammercurls(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Die Hanteln halten Sie während der gesamten Ausführung im Neutralgriff." +
                " Der Bewegungsablauf ist ansonsten grundsätzlich gleich: " +
                "Die Kurzhanteln heben Sie von seitlich des Körpers nach oben, indem Sie die Ellbogen beugen.");

            logger.Information("Infos Hammercurls");
        }

        private void InfoButtonArnoldDips(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Drücken Sie sich kräftig aus den Oberarmen nach oben in den Stütz zurück. " +
                "Je tiefer Sie gehen, desto mehr beugen sich die Ellenbogen. Der Reiz für Ihren Trizeps wird stärker.");

            logger.Information("Infos Arnold Dips");
        }

        private void InfoButtonPushups(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Der Push-Up ist eine Übung zur Kräftigung von Brust-, Schulter-, Arm- und Rumpfmuskulatur. " +
                "Sie drücken sich dabei aus einer liegenden Position mit den Armen vom Boden weg.");

            logger.Information("Infos Push Ups");
        }

        private void InfoButtonTricepPress(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie beginnen das Trizepsdrücken über Kopf mit dem Seil, indem die Arme nach oben gestreckt sind. " +
                "Senken Sie die Unterarme nach hinten ab, bis sich diese leicht oberhalb deines Kopfes befinden. " +
                "Die Oberarme bleiben gerade nach oben gestreckt und bewegen sich während der Ausführung nicht. " +
                "Im Anschluss ziehen Sie die Unterarme wieder nach oben.");

            logger.Information("Infos Tricep Press");
        }

        private void InfoButtonKickbacks(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Bei dieser Übung gibt es 2 Varianten, einmal die stehenden und einmal die knienden Kickbacks. " +
                "Sie beginnen indem Sie den linken Unterarm nach oben beugen. Sie bewegen dabei nur den Unterarm" +
                "Anschließend sollte Ihr Arm fast vollständig gestreckt sein, Unter- und Oberarm bilden eine parallele Linie. " +
                "Kehren Sie nun wieder in die Ausgangsposition zurück.");

            logger.Information("Infos Kickbacks");
        }

        private void InfoButtonSZCurls(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Stellen Sie sich aufrichrig hin. Die Beine ungefähr schulterbreit und die SZ-Stange vor Ihnen im Untergriff. " +
                "Ziehen sie die SZ-Stange mit den Unterarme nach Oben, bis die Arme einen 90° Winkel haben. " +
                "Danach wieder in Ausgangsposition zurückkehren.");

            logger.Information("Infos SZ-Curls");
        }

        private void zeigeDataFenster(string nachricht)
        {
            try
            {
                DatenFenster daten = new DatenFenster(einheiten, this.uebungListBox);
                daten.einheitenName.Text = nachricht;
                daten.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fehler beim Anzeigen des Datenfensters.");
            }
        }

        private void addButtonHammercurls(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Hammercurls");
        }

        private void addButtonArnoldDips(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Arnold-Dips");
        }

        private void addButtonPushups(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Push-Ups");
        }

        private void addButtonTricepPress(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Tricep-Press");
        }

        private void addButtonKickbacks(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Kickbacks");
        }

        private void addButtonSZCurls(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("SZ-Curls");
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            einheiten.Einheiten.Clear();
            foreach (nutzerEingabe item in uebungListBox.Items)
            {
                einheiten.Einheiten.Add(item);
            }
            this.Close();
            logger.Information("Fenster geschlossen");
        }
        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (uebungListBox.Items.Count == 0)
                {
                    MessageBox.Show("Bitte tragen Sie Übungen ein. ");
                    logger.Information("ListBox Werte sind leer");
                }
                else
                {
                    foreach (var item in uebungListBox.Items)
                    {
                        timerDaten.timerDaten.Add((nutzerEingabe)item);
                    }

                    timer = new HauptprogrammTimer(timerDaten.timerDaten, validList);
                    timer.derzeitigeGrundEinheitTextBox.Text = "Armtraining";
                    einheiten.Einheiten.Clear();
                    foreach (nutzerEingabe item in uebungListBox.Items)
                    {
                        einheiten.Einheiten.Add(item);
                    }
                    this.Close();
                    timer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fehler beim Klicken des OK-Buttons.");
            }
        }

        private void buttonLoeschen_Click(object sender, RoutedEventArgs e)
        {

            if (uebungListBox.SelectedItem != null)
            {
                int selectedIndex = uebungListBox.SelectedIndex;
                //session.Einheiten.RemoveAt(selectedIndex);

                uebungListBox.Items.RemoveAt(selectedIndex);

                einheiten.Einheiten.Clear();
                foreach (nutzerEingabe item in uebungListBox.Items)
                {
                    einheiten.Einheiten.Add(item);
                }

                if (selectedIndex >= 0 && selectedIndex < session.Einheiten.Count)
                {

                    session.Einheiten.RemoveAt(selectedIndex);
                    logger.Information("Session entfernt");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Übung aus, die Sie löschen möchten.");
            }
        }

    }

}
