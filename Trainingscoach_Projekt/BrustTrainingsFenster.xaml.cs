using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for BrustTrainingsFenster.xaml
    /// </summary>
    public partial class BrustTrainingsFenster : Window
    {
        public BrustTrainingsFenster()
        {
            InitializeComponent();
        }

        private void infoButtonPushUps(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sie legen sich zunächst flach mit dem Bauch auf den Boden. Stützen sie sich anschließend auf ihern Händen und Zehen ab. Nun senken Sie sich wieder und wiederholen diese Übung. ");
        }

        private void infoButtonButterfly(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sie setzen sich aufrecht auf einem Gerät und bewegen das Gewicht, indem Sie Ihre gespreizten Arme vor Ihrem Oberkörper zusammendrücken .");
        }

        private void infoButtonCableFly(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sie nehmen ein Seil an einem Gerät und halten es an beiden Armen. Nun spreitzen sie ihre Arme auseinander und ziehen es zusammen. Wiederholen Sie diese Übung am Besten.");
        }

        private void infoButtonDumbbellPullover(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Strecken Sie Ihre Arme zur Decke über Ihre Brust. Ihre Handflächen sollten einander zugewandt sein und Ihre Ellbogen sollten leicht gebeugt sein. strecken Sie die Gewichte nach hinten und über Ihren Kopf und wieder zurück.");
        }

        private void infoButtonDumbbellFlys(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Strecken Sie Ihre Arme zur Decke über Ihre Brust. Ihre Handflächen sollten einander zugewandt sein und Ihre Ellbogen sollten leicht gebeugt sein. strecken Sie die Gewichte nach außen und wieder nach innen.");
        }

        private void infoButtonBenchPress(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Legen Sie sich mit dem Rücken auf eine Bank und drücken Sie mit beiden Händen eine Großhantel nach oben und wieder zurück.");
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

        private void zeigeDataFenster(string nachricht)
        {
            DatenFenster daten = new DatenFenster();
            daten.einheitenName.Text = nachricht;
            daten.ShowDialog();
            uebungListBox.Items.Add(daten.nutzer);
        }

        private void addButtonPushUps(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Push-Ups");
        }

        private void addButtonButterfly(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Butterfly");
        }

        private void addButtonCableFly(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Cable Fly");
        }

        private void addButtonDumbbellPullover(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Dumbbell Pullover");
        }

        private void addButtonDumbbellFlys(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Dumbbell Flys");
        }

        private void addButtonBenchPress(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Bench Press");
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

        private void Add()
        {
            TimerDaten timerDaten = new TimerDaten();

            foreach (var item in uebungListBox.Items)
            {
                try
                {
                    timerDaten.timerDaten.Add(item.ToString());

                }
                catch
                {
                    MessageBox.Show("Bitte geben Sie gültige Werte ein.");
                }
            }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (uebungListBox.Items.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie die Übungen aus.");
                return;
            }

            try
            {
                Add();
                HauptprogrammTimer timer = new HauptprogrammTimer();
                this.Close();
                timer.ShowDialog();
            }
            catch (FormatException)
            {
                MessageBox.Show("Bitte geben Sie gültige Werte ein.");
            }


        }
    }
}
