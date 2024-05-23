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
    /// Interaction logic for ArmTrainingsFenster.xaml
    /// </summary>
    public partial class ArmTrainingsFenster : Window
    {
        ListBox listbox;

        public ArmTrainingsFenster()
        {
            InitializeComponent();
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

        private void InfoButtonHammercurls(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Die Hanteln halten Sie während der gesamten Ausführung im Neutralgriff." +
                " Der Bewegungsablauf ist ansonsten grundsätzlich gleich: " +
                "Die Kurzhanteln heben Sie von seitlich des Körpers nach oben, indem Sie die Ellbogen beugen.");
        }

        private void InfoButtonArnoldDips(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Drücken Sie sich kräftig aus den Oberarmen nach oben in den Stütz zurück. " +
                "Je tiefer Sie gehen, desto mehr beugen sich die Ellenbogen. Der Reiz für Ihren Trizeps wird stärker.");
        }

        private void InfoButtonPushups(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Der Pushup ist eine Übung zur Kräftigung von Brust-, Schulter-, Arm- und Rumpfmuskulatur. " +
                "Sie drücken sich dabei aus einer liegenden Position mit den Armen vom Boden weg.");
        }

        private void InfoButtonTricepPress(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie beginnen das Trizepsdrücken über Kopf mit dem Seil, indem die Arme nach oben gestreckt sind. " +
                "Senken Sie die Unterarme nach hinten ab, bis sich diese leicht oberhalb deines Kopfes befinden. " +
                "Die Oberarme bleiben gerade nach oben gestreckt und bewegen sich währen der Ausführung nicht. " +
                "Im Anschluss ziehen Sie die Unterarme wieder nach oben.");
        }

        private void InfoButtonKickbacks(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Bei dieser Übung gibt es 2 Varianten, einmal die stehenden und einmal die knienden Kickbacks. " +
                "Sie beginnen indem Sie den linken Unterarm nach oben beugen. Sie bewegen dabei nur den Unterarm" +
                "Anschließend sollte dein Arm fast vollständig gestreckt sein, Unter- und Oberarm bilden eine parallele Linie. " +
                "Kehren Sie nun wieder in die Ausgangsposition zurück.");
        }

        private void InfoButtonSZCurls(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Stellen Sie sich aufrichrig hin. Die Beine ungefähr schulterbreit und die SZ-Stange vor Ihnen im Untergriff. " +
                "Ziehen sie die SZ-Stange mit den Unterarme nach Oben, bis die Arme einen 90° Winkel haben. " +
                "Danach wieder in Ausgangsposition zurückkehren.");
        }

        private void addButtonHammercurls(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.einheitenName.Text = "Hammercurls";
            daten.ShowDialog();
        }

        private void addButtonArnoldDips(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.einheitenName.Text = "Arnold-Dips";
            daten.ShowDialog();
        }

        private void addButtonPushups(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.einheitenName.Text = "Push-Ups";
            daten.ShowDialog();
        }

        private void addButtonTricepPress(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.einheitenName.Text = "Tricep Press";
            daten.ShowDialog();
        }

        private void addButtonKickbacks(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.einheitenName.Text = "Kickbacks";
            daten.ShowDialog();
        }

        private void addButtonSZCurls(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.einheitenName.Text = "SZ-Curls";
            daten.ShowDialog();
        }
    }

}
