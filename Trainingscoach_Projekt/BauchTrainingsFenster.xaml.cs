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
    public partial class BauchTrainingsFenster : Window
    {
        TimerDaten timerDaten = new TimerDaten();
        public Session einheiten;
        Session session = new Session();
        public static HauptprogrammTimer timer;
        List<bool> validList;
        public BauchTrainingsFenster(Session einheiten)
        {
            InitializeComponent();
            this.einheiten = einheiten;
            foreach (var item in einheiten.Einheiten)
            {
                uebungListBox.Items.Add(item);
                session.Einheiten.Add(item);
            }
        }   

        private void infoButtonCrunches(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie beginnen mit einer liegenden Ausgangsposition und heben den Oberkörper mit leichter Krümmung an. ");
        }

        private void infoButtonRope(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Kniend heben Sie das Seil in der Hand und heben den Oberkörper an. Wenn Sie sich wieder zurück krümmen, ziehen Sie das Seil mit sich mit. ");
        }

        private void infoButtonTouchToeTwist(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Diese Übung führen Sie im Stehen aus. Sie bewegen ihre Hand zum entgegengesetzt Fuß. Stärkt die seitlichen und geraden Bauchmuskeln. ");
        }

        private void infoButtonCandle(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Diese Übung ist zugleich auch eine Yoga Figur. Sie legen sich zunächst am Boden Dannach halten Sie ihren Körper in vertikaler Position nach oben. Je mehr sie die Position halten, desto besser. ");
        }

        private void infoButtonSitUps(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie legen sich bei dieser Übung mit dem Rücken auf dem Boden und halten bei dieser Übung ihre Füße aufgestellt. Schließlich bewegen Sie ihren Oberkörper langsam nach oben. ");
        }

        private void infoButtonSitUpsBall(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sie legen sich bei dieser Übung auf einen Gymnastik-Ball und stellen ihre Füße auf den Boden. Schließlich bewegen Sie ihren Oberkörper langsam nach oben. ");
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
            DatenFenster daten = new DatenFenster(einheiten, uebungListBox);
            daten.einheitenName.Text = nachricht;
            daten.ShowDialog();
            // uebungListBox.Items.Add(daten.nutzer);
        }

        private void addButtonCrunches(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Crunches");
        }

        private void addButtonCrunchesRope(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Crunches Rope");
        }

        private void addButtonTouchToeTwist(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Touch-Toe-Twist");
        }

        private void addButtonCandle(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Candle");
        }

        private void addButtonSitUps(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Sit-Ups");
        }

        private void addButtonSitUpsBall(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Sit-Ups-Ball");
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

        private void buttonOK_Click(object sender, RoutedEventArgs e)
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

                HauptprogrammTimer timer = new HauptprogrammTimer(timerDaten.timerDaten, validList);
                timer.derzeitigeGrundEinheitTextBox.Text = "Bauchtraining";
                this.Close();
                timer.ShowDialog();
            }
        }
    }
}
