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
        public GrundtrainingseinheitDaten daten;
        private bool buttonClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ListBoxSelect()
        {
            AuswaehlenSpezifischeUebungFenster spezifischeUebungFenster = new AuswaehlenSpezifischeUebungFenster(ListBoxGrundeinheit);

            if (ListBoxGrundeinheit.SelectedIndex == -1 && buttonClicked == false)
            {
                MessageBox.Show("Bitte wählen Sie eine Trainings-Session aus. ");

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

        private void buttonHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            GrundtrainingseinheitenWindow window = new GrundtrainingseinheitenWindow();
            window.ShowDialog();
            string uebergabeText = window.uebergabeText;
            ListBoxGrundeinheit.Items.Add(uebergabeText);

        }

        private void buttonAuswaehlen_Click(object sender, RoutedEventArgs e)
        {
            AuswaehlenSpezifischeUebungFenster spezifischesFenster = new AuswaehlenSpezifischeUebungFenster(ListBoxGrundeinheit);
            ListBoxSelect();
            spezifischesFenster.ShowDialog();

            buttonClicked = true;
            ListBoxSelect();
        }
    }
}