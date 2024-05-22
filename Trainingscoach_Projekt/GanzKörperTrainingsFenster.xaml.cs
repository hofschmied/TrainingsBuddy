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
        public GanzKörperTrainingsFenster()
        {
            InitializeComponent();
        }

        private void infoButtonPushUps(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie legen sich zunächst flach mit dem Bauch auf den Boden. Stützen sie sich anschließend auf ihern Händen und Zehen ab. Nun senken Sie sich wieder und wiederholen diese Übung. ");
        }

        private void infoButtonSitUps(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie legen sich bei dieser Übung mit dem Rücken auf dem Boden und halten bei dieser Übung ihre Füße aufgestellt. Schließlich bewegen Sie ihren Oberkörper langsam nach oben.  ");
        }

        private void infoButtonSquats(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Man steht aufrecht und beugt dann die Knie, um in die Hocke zu gehen. " +
            "Dabei wird der Rücken nicht gerundet oder überstreckt. Das erreicht man, " +
            "indem man die Hüfte beugt und den Oberkörper nach vorne neigt. " +
            "Von der Hocke aus geht man wieder gerade nach oben in die Ausgangslage");
        }

        private void infoButtonButterfly(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie setzen sich aufrecht auf einem Gerät und bewegen das Gewicht, indem Sie Ihre gespreizten Arme vor Ihrem Oberkörper zusammendrücken .");
        }


        private void infoButtonBulgarianSplitsSquats(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Bei dieser Übung stellst du eines deiner Beine auf eine Bank und gehst mit dem anderen Bein langsam nach in die Knie");
        }

        private void infoButtonCrunches(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie beginnen mit einer liegenden Ausgangsposition und heben den Oberkörper mit leichter Krümmung an. ");
        }

        private void addButtonPushUps(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.ShowDialog();
        }

        private void addButtonSitUps(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.ShowDialog();
        }
        private void addButtonSquats(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.ShowDialog();
        }

        private void addButtonButterfly(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.ShowDialog();
        }
        private void addButtonBulgarianSplitsSquats(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.ShowDialog();
        }

        private void addButtonCrunches(object sender, MouseButtonEventArgs e)
        {
            DatenFenster daten = new DatenFenster();
            daten.ShowDialog();
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
    }
}
