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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GrundtrainingseinheitDaten daten = new GrundtrainingseinheitDaten();
        private bool buttonClicked = false;

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
                    BeinTrainingsFenster beinTrainingsFenster = new BeinTrainingsFenster();
                    beinTrainingsFenster.ShowDialog();
                }
                else if (selectedItem.Contains("Arm-Training"))
                {
                    ArmTrainingsFenster armTrainingsFenster = new ArmTrainingsFenster();
                    armTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Rücken-Training"))
                {
                    RueckenTrainingsFenster rueckenTrainingsFenster = new RueckenTrainingsFenster();
                    rueckenTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Brust-Training"))
                {
                    BrustTrainingsFenster brustTrainingsFenster = new BrustTrainingsFenster();
                    brustTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Bauch-Training"))
                {
                    BauchTrainingsFenster bauchTrainingsFenster = new BauchTrainingsFenster();
                    bauchTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Ganzkörper-Training"))
                {
                    GanzKörperTrainingsFenster ganzKörperTrainingsFenster = new GanzKörperTrainingsFenster();
                    ganzKörperTrainingsFenster.ShowDialog();
                }

                else if (selectedItem.Contains("Cardio"))
                {
                    CardioFenster cardioFenster = new CardioFenster();
                    cardioFenster.ShowDialog();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kleineHinzufuegenAktion(object sender, RoutedEventArgs e)
        {
            GrundtrainingseinheitenWindow window = new GrundtrainingseinheitenWindow();
            window.ShowDialog();
            string uebergabeText = window.uebergabeText;
            ListBoxGrundeinheit.Items.Add(uebergabeText);
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