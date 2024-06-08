using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace Trainingscoach_Projekt
{
    public partial class MainWindow : Window
    {
        public GrundtrainingseinheitDaten daten = new GrundtrainingseinheitDaten();
        private bool buttonClicked = false;
        List<Session> sessions = new List<Session>();
        private string filePath = "sessions.txt";
        public bool valid = false;

        public MainWindow()
        {
            InitializeComponent();

            sessionLaden();
        }

        public void FensterAuswahl()
        {
            if (ListBoxGrundeinheit.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte wählen Sie eine Trainings-Session aus.");
            }
            else
            {
                int selectedIndex = ListBoxGrundeinheit.SelectedIndex;
                Session selectedSession = sessions[selectedIndex];

                string grundeinheit = selectedSession.Grundeinheit;

                if (grundeinheit.Contains("Bein-Training"))
                {
                    BeinTrainingsFenster beinTrainingsFenster = new BeinTrainingsFenster(selectedSession);
                    beinTrainingsFenster.ShowDialog();
                }
                else if (grundeinheit.Contains("Arm-Training"))
                {
                    ArmTrainingsFenster armTrainingsFenster = new ArmTrainingsFenster(selectedSession);
                    armTrainingsFenster.ShowDialog();
                    this.valid = armTrainingsFenster.valid;
                }
                else if (grundeinheit.Contains("Rücken-Training"))
                {
                    RueckenTrainingsFenster rueckenTrainingsFenster = new RueckenTrainingsFenster(selectedSession);
                    rueckenTrainingsFenster.ShowDialog();
                }
                else if (grundeinheit.Contains("Brust-Training"))
                {
                    BrustTrainingsFenster brustTrainingsFenster = new BrustTrainingsFenster(selectedSession);
                    brustTrainingsFenster.ShowDialog();
                }
                else if (grundeinheit.Contains("Bauch-Training"))
                {
                    BauchTrainingsFenster bauchTrainingsFenster = new BauchTrainingsFenster(selectedSession);
                    bauchTrainingsFenster.ShowDialog();
                }
                else if (grundeinheit.Contains("Ganzkörper-Training"))
                {
                    GanzKörperTrainingsFenster ganzKörperTrainingsFenster = new GanzKörperTrainingsFenster(selectedSession);
                    ganzKörperTrainingsFenster.ShowDialog();
                }
                else if (grundeinheit.Contains("Cardio"))
                {
                    CardioFenster cardioFenster = new CardioFenster(selectedSession);
                    cardioFenster.ShowDialog();
                }
            }
        }

        private void buttonHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            GrundtrainingseinheitenWindow window = new GrundtrainingseinheitenWindow();
            window.ShowDialog();
            if (window.uebergabeText != null)
            {
                string uebergabeText = window.uebergabeText;

                Session neueSession = new Session(uebergabeText);
                neueSession.Grundeinheit = window.uebergabeText.Split("-|~#+*")[1];
                sessions.Add(neueSession);
                ListBoxGrundeinheit.Items.Add(neueSession.ToString());

                sessionSpeichern();
            }
        }

        private void buttonAuswaehlen_Click(object sender, RoutedEventArgs e)
        {
            FensterAuswahl();
            sessionSpeichern();
        }

        private void buttonLoeschen_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxGrundeinheit.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte wählen Sie eine Trainings-Session aus, die Sie löschen möchten.");
            }
            else
            {
                int selectedIndex = ListBoxGrundeinheit.SelectedIndex;
                ListBoxGrundeinheit.Items.RemoveAt(selectedIndex);
                sessions.RemoveAt(selectedIndex);

                sessionSpeichern();
            }
        }

        public void sessionSpeichern()
        {
            string json = JsonConvert.SerializeObject(sessions);
            File.WriteAllText(filePath, json);


        }

        public void sessionLaden()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                sessions = JsonConvert.DeserializeObject<List<Session>>(json);
                ListBoxGrundeinheit.Items.Clear();
                foreach (Session session in sessions)
                {
                    ListBoxGrundeinheit.Items.Add(session.ToString());
                }
            }
        }

        private void buttonAufgaben_Click(object sender, RoutedEventArgs e)
        {
            QuestFenster questFenster = new QuestFenster(valid);
            questFenster.ShowDialog();
        }
    }
}