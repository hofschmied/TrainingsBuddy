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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trainingscoach_Projekt
{
    public partial class MainWindow : Window
    {
        // Das ist die dekleration Zone
        public GrundtrainingseinheitDaten daten = new GrundtrainingseinheitDaten();
        private bool buttonClicked = false;
        List<Session> sessions = new List<Session>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void FensterAuswahl()
        {
            if (ListBoxGrundeinheit.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte wählen Sie eine Trainings-Session aus.");
            }
            else
            {
                string selectedItem = ListBoxGrundeinheit.SelectedItem.ToString();

                if (selectedItem.Contains("Bein-Training"))
                {
                    BeinTrainingsFenster beinTrainingsFenster = new BeinTrainingsFenster(daten);
                    beinTrainingsFenster.ShowDialog();
                }
                else if (selectedItem.Contains("Arm-Training"))
                {
                    ArmTrainingsFenster armTrainingsFenster = new ArmTrainingsFenster(daten);
                    armTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Rücken-Training"))
                {
                    RueckenTrainingsFenster rueckenTrainingsFenster = new RueckenTrainingsFenster(daten);
                    rueckenTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Brust-Training"))
                {
                    BrustTrainingsFenster brustTrainingsFenster = new BrustTrainingsFenster(daten);
                    brustTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Bauch-Training"))
                {
                    BauchTrainingsFenster bauchTrainingsFenster = new BauchTrainingsFenster(daten);
                    bauchTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Ganzkörper-Training"))
                {
                    GanzKörperTrainingsFenster ganzKörperTrainingsFenster = new GanzKörperTrainingsFenster(daten);
                    ganzKörperTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Cardio"))
                {
                    CardioFenster cardioFenster = new CardioFenster(daten);
                    cardioFenster.ShowDialog();
                }
            }
        }

        private void buttonHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            GrundtrainingseinheitenWindow window = new GrundtrainingseinheitenWindow();
            window.ShowDialog();
            string uebergabeText = window.uebergabeText;
            
            Session sozialesExperiment = new Session(uebergabeText);
            sozialesExperiment.Grundeinheit = window.uebergabeText.Split(" ")[1];
            sessions.Add(sozialesExperiment);
            ListBoxGrundeinheit.Items.Add(sozialesExperiment.ToString());
        }


        private void buttonAuswaehlen_Click(object sender, RoutedEventArgs e)
        {
            FensterAuswahl();
        }


        private void buttonLoeschen_Click(object sender, RoutedEventArgs e)
        {
            daten.Remove();
        }
    }
}