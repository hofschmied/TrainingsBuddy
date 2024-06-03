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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace Trainingscoach_Projekt
{
    public partial class GrundtrainingseinheitenWindow : Window
    {
        GrundtrainingseinheitDaten grundtrainingseinheitDaten;

        public string uebergabeText { get; set; }

        public List<string> strings = new List<string>();

        public GrundtrainingseinheitenWindow()
        {
            InitializeComponent();

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBoxTrainingsName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FachBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (GrundTrainingsEinheitBox.SelectedItem != null)
            {
                if (grundtrainingseinheitDaten == null)
                {
                    grundtrainingseinheitDaten = new GrundtrainingseinheitDaten();
                }

                grundtrainingseinheitDaten.grundEinheit = GrundTrainingsEinheitBox;

                string selectedGrundEinheit = (GrundTrainingsEinheitBox.SelectedItem as ComboBoxItem).Content.ToString();

                grundtrainingseinheitDaten.sessionName = TextBoxTrainingsName.Text;

                this.uebergabeText = grundtrainingseinheitDaten.sessionName + " (" + selectedGrundEinheit + ") (" + DateTime.Now + ")";

                strings.Add(grundtrainingseinheitDaten.sessionName);

                this.Close();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Grund-Trainingseinheit aus.");
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

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
