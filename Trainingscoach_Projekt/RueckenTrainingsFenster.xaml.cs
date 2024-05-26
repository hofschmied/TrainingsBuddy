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
    /// Interaction logic for RueckenTrainingsFenster.xaml
    /// </summary>
    public partial class RueckenTrainingsFenster : Window
    {
        public RueckenTrainingsFenster()
        {
            InitializeComponent();
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
            }
        }

        private void fensterSchließen(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void fensterMinimieren(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void InfoButtonGoodMornings(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Beugen Sie Ihren Oberkörper nach vorne und unten. Die Knie dürfen nun leicht nach vorne wandern, " +
                "sollten sich jedoch über den Fersen befinden. Wichtig ist jedoch, dass die Bewegung nur aus dem Hüftgelenk stammt. " +
                "Der Rücken sollte weiterhin in einer leichten Hohlkreuzstellung verbleiben." +
                "Im Anschluss drückst du den Oberkörper langsam wieder nach oben.");
        }

        private void InfoButtonDeadlift(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Der Stand sollte zwischen hüft- und schulterbreit und Ihr Mittelfuß unter der Stange sein. " +
                "Ihre Knie leicht beugen und Ihr Gesäß nach hinten schieben. " +
                "Sie sollten Ihr Rücken gerade halten und die Stange mit beiden Händen mit einer Daumenlänge Abstand zum Oberschenkel greifen. " +
                "Die Stange mit einer Parallelbewegung von der Schultern, Gesäß und Knie eng am Körper nach oben ziehen. " +
                "Wenn die Stange an den Knien vorbei ist, sollten Sie ihre Hüfte nach vorn schieben und aufrichten");
        }

        private void InfoButtonPullDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Ziehen Sie die Gewichte nach unten, bis vor deine Brust. " +
                "Bei dieser Bewegung atmest du aus, während du beim Zurückführen einatmest. " +
                "Der restliche Körper bewegt sich nicht. " +
                "Die Kraft kommt ausschließlich aus dem Rückenmuskel und dem seitlichen Oberarm.");
        }

        private void InfoButtonRowDumbbells(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Nehmen Sie Ihre Hanteln im Obergriff. " +
                "Beim Ausatmen ziehen Sie die Arme nach oben und führen die Ellenbogen direkt neben dem Oberkörper her. " +
                "Wenn sich die Kurzhanteln beim Rudern vorgebeugt an der Seite deines Körpers befinden, stoppen Sie kurz. " +
                "Ihre Ellenbogen sind höher als Ihr Rücken. " +
                "Im Anschluss führen Sie die Kurzhanteln beim Einatmen wieder nach unten, bis Ihre Arme fast vollständig durchhängen.");
        }

        private void InfoButtonShrugs(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Ziehen Sie Ihre Schulterblätter langsam nach oben, um die Kurzhanteln anzuheben. " +
                "Die Arme bleiben kontinuierlich in der gleichen, leicht gebeugten Haltung. Beim Hochziehen der Hanteln atmen Sie aus. " +
                "Halten Sie das Gewicht kurz und lassen es beim Einatmen wieder ab.");
        }

        private void InfoButtonHyperextensions(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Senken Sie den gesamten Oberkörper nach unten. " +
                "Behalten Sie einen geraden Rücken und senken Sie den Oberkörper so weit, " +
                "bis sich Beine und Oberkörper in einem rechten Winkel befinden. " +
                "Ihre Arme sind vor deiner Brust verschränkt. " +
                "Im Anschluss kehren Sie mit Ihrem Oberkörper in die Ausgangsposition zurück. " +
                "Die Kraft kommt ausschließlich aus dem unteren Rücken.");
        }

        private void zeigeDataFenster(string nachricht)
        {
            DatenFenster daten = new DatenFenster();
            daten.einheitenName.Text = nachricht;
            daten.ShowDialog();
            uebungListBox.Items.Add(daten.nutzer);
        }

        private void addButtonGoodMornings(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Good Mornings");
        }

        private void addButtonDeadlift(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Deadlift");
        }

        private void addButtonPullDown(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Pull Down");
        }

        private void addButtonRowDumbbels(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Row Dumbbels");
        }

        private void addButtonShrugs(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Shrugs");
        }

        private void addButtonHyperextensions(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Hyperextensions");
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonLoeschen_Click(object sender, RoutedEventArgs e)
        {
            if (uebungListBox.SelectedItem != null)
            {
                uebungListBox.Items.Remove(uebungListBox.SelectedItem);
            }
        }
    }
}
