﻿using System;
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

namespace Trainingscoach_Projekt
{
    public partial class CardioFenster : Window
    {
        TimerDaten timerDaten = new TimerDaten();
        public Session einheiten;
        Session session = new Session();
        List<bool> validList;
        public CardioFenster(Session einheiten)
        {
            InitializeComponent();
            this.einheiten = einheiten;
            foreach (var item in einheiten.Einheiten)
            {
                uebungListBox.Items.Add(item);
                session.Einheiten.Add(item);
            }
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

        private void InfoButtonCycling(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Steigen Sie sich auf das Fahrrad auf und treten Sie die Pedale.");
        }

        private void InfoButtonRunning(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Stehen Sie auf das Laufband und schalten Sie es ein. " +
                "Nun können Sie die Geschwindigkeit angeben und anfangen zu laufen.");
        }

        private void InfoButtonJumping(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Holen Sie sich ein SpringSeil und Schwingen Sie es über Ihren Kopf. " +
                "Springen Sie kurz bevor das Seil ihre Beine berührt. Wiederholen Sie diesen Ablauf.");
        }

        private void InfoButtonStepMill(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Stehen Sie auf der Maschiene und Schalten Sie es ein. " +
                "Sie können nun die Geschwindigkeit angeben. Sobald die Maschiene startet können Sie treppenlaufen.");
        }

        private void InfoButtonEllipticalTrainer(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Bei einem Ellipsentrainer setzen Sie nicht mit den Füßen auf dem Boden auf, " +
                "sondern die Füße durchlaufen eine elliptische Bewegung in der Luft. Beim Laufen hingegen stoßen die Füße auf den Boden auf, " +
                "und Knöchel und Knie spüren die Belastung, was zu Verletzungen führen kann.");
        }

        private void InfoButtonRowing(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Beim Rudern kommt es auf flüssige Bewegungen an, nicht auf kraftvolles Reißen und Loslassen. " +
                "Die Ruderstange wird kraftvoll zum Körper gezogen und wieder zurückgeführt, " +
                "dabei kommt es nie zu einem kompletten Lockerlassen und Wiederansetzen der Kraft.");
        }

        private void zeigeDataFenster(string nachricht)
        {
            DatenFenster daten = new DatenFenster(einheiten, uebungListBox);
            daten.einheitenName.Text = nachricht;
            daten.ShowDialog();
            // uebungListBox.Items.Add(daten.nutzer);
        }

        private void addButtonCycling(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Cycling");
        }

        private void addButtonTreadmillRunning(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Treadmill Running");
        }

        private void addButtonRopeJumping(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Rope Jumping");
        }

        private void addButtonStepMill(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Stepmill");
        }

        private void addButtonEllipticalTrainer(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Elliptical Trainer");
        }

        private void addButtonStationaryRowing(object sender, MouseButtonEventArgs e)
        {
            zeigeDataFenster("Stationary Rowing");
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
                timer.derzeitigeGrundEinheitTextBox.Text = "Cardio";
                this.Close();
                timer.ShowDialog();
            }
        }
    }
}
