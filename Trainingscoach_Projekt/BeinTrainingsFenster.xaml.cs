using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;

namespace Trainingscoach_Projekt
{
    /// <summary>
    /// Interaction logic for BeinTrainingsFenster.xaml
    /// </summary>
    public partial class BeinTrainingsFenster : Window
    {

        TimerDaten timerDaten = new TimerDaten();
        public Session einheiten;
        Session session = new Session();
        List<bool> validList;
        private static readonly Serilog.ILogger logger = LoggerClass.logger;

        public BeinTrainingsFenster(Session einheiten)
        {
            InitializeComponent();
            this.einheiten = einheiten;
            foreach (var item in einheiten.Einheiten)
            {
                uebungListBox.Items.Add(item);
                session.Einheiten.Add(item);
            }
            logger.Information("BeinTrainingsFenster initialisiert");
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
                logger.Error(ex, "Fehler beim Bewegen des Fensters.");
            }
        }

        private void fensterSchließen(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            logger.Information("Fenster geschlossen");
        }

        private void fensterMinimieren(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void InfoButtonSquats(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Man steht aufrecht und beugt dann die Knie, um in die Hocke zu gehen. " +
                "Dabei wird der Rücken nicht gerundet oder überstreckt. Das erreicht man, " +
                "indem man die Hüfte beugt und den Oberkörper nach vorne neigt. " +
                "Von der Hocke aus geht man wieder gerade nach oben in die Ausgangslage");

            logger.Information("Infos Squats");
        }

        private void InfoButtonLegPress(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Setzen Sie sich auf die Beinpresse und lehnen Sie sich zurück. " +
                "Stellen Sie Ihre Füße hüftbreit mittig auf die Druckplatte. Ihre Fußspitzen sollten leicht nach außen zeigen, damit Sie Ihre Knie entlastest. " +
                "Nun drücken Sie sich von der Druckplatte weg und lassen sich langsam wieder ab.");

            logger.Information("Infos Leg Press");
        }

        private void InfoButtonLunges(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Machen Sie mit einem Bein einen großen Schritt nach vorne. " +
                "Nun beugen Sie das vordere Bein, bis der Winkel zwischen Unter- und Oberschenkel etwa 90 Grad beträgt. " +
                "Nachdem Sie den tiefsten Punkt erreicht haben, bringen Sie sich wieder in die Ausgangsstellung zurück.");

            logger.Information("Infos Lunges");
        }

        private void InfoButtonDeadlift(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Der Stand sollte zwischen hüft- und schulterbreit und Ihr Mittelfuß unter der Stange sein. " +
                "Ihre Knie leicht beugen und Ihr Gesäß nach hinten schieben. Sie sollten Ihr Rücken gerade halten und die Stange mit beiden Händen mit einer Daumenlänge Abstand zum Oberschenkel greifen. " +
                "Die Stange mit einer Parallelbewegung von der Schultern, Gesäß und Knie eng am Körper nach oben ziehen. " +
                "Wenn die Stange an den Knien vorbei ist, sollten Sie ihre Hüfte nach vorn schieben und aufrichten");

            logger.Information("Infos Deadlift");
        }

        private void InfoButtonBulgarianSplitsSquats(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Bei den Bulgarian Split Squats bewegst du ausschließlich deine Beine. " +
                "Kraft aus dem hinteren Bein: Die Kraft für die Auf- und Abwärtsbewegung stammt bei den Bulgarian Split Squats nur aus dem vorderen Bein, " +
                "da du beide Körperseiten alternierend bewegst. Achte darauf, dass du das hintere Bein nicht beanspruchst.");

            logger.Information("Infos Bulgarian Splits Squats");
        }

        private void InfoButtonLegExtensions(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Legen Sie Ihre Hände auf die Handstangen. " +
                "Heben Sie das Gewicht beim Ausatmen an, bis Ihre Beine fast gerade sind. " +
                "Halten Sie den Rücken an der Rückenlehne und beugen Sie den Rücken nicht. " +
                "Atmen Sie aus und senken Sie das Gewicht wieder in die Ausgangsposition.");

            logger.Information("Infos Leg Extensions");
        }

        private void zeigeDataFenster(string nachricht)
        {
            try
            {
                DatenFenster daten = new DatenFenster(einheiten, uebungListBox);
                daten.einheitenName.Text = nachricht;
                daten.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fehler beim Anzeigen des Datenfensters.");
            }
        }

        private void addButtonSquats(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Squats");
        }

        private void addButtonLegPress(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Leg Press");
        }

        private void addButtonLunges(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Lunges");
        }

        private void addButtonDeadlift(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Deadlift");
        }

        private void addButtonBulgarianSplitsSquats(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Bulgarian Splits Squats");
        }

        private void addButtonLegExtensions(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Leg Extensions");
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            logger.Information("Fenster geschlossen");
        }


        private void buttonLoeschen_Click(object sender, RoutedEventArgs e)
        {
            if (uebungListBox.SelectedItem != null)
            {
                uebungListBox.Items.Remove(uebungListBox.SelectedItem);
                logger.Information("Item entfernt");
            }
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

                    HauptprogrammTimer timer = new HauptprogrammTimer(timerDaten.timerDaten, validList);
                    timer.derzeitigeGrundEinheitTextBox.Text = "Beintraining";
                    this.Close();
                    timer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fehler beim Klicken des OK-Buttons.");
            }
        }
    }
}
