using System;
using System.Windows;
using System.Windows.Controls;

namespace Trainingscoach_Projekt
{
    public partial class DatenFenster : Window
    {
        public nutzerEingabe nutzer;
        public GrundtrainingseinheitDaten einheiten;
        private ListBox uebungListBox;

        public DatenFenster(GrundtrainingseinheitDaten einheiten, ListBox uebungListBox)
        {
            InitializeComponent();
            this.einheiten = einheiten;
            this.uebungListBox = uebungListBox;
        }

        private void ListBoxItemsAdd()
        {
            nutzer = new nutzerEingabe(einheitenName.Text, int.Parse(anzahlSets.Text), double.Parse(dauer.Text));
            einheiten.einheitenList.Add(nutzer);
            uebungListBox.Items.Clear();
            foreach (var item in einheiten.einheitenList)
            {
                uebungListBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (anzahlSets.Text == "" || dauer.Text == "")
            {
                MessageBox.Show("Bitte geben Sie gültige Werte ein.");
                return;
            }

            try
            {
                int sets = int.Parse(anzahlSets.Text);
                double dauerWert = double.Parse(dauer.Text);

                ListBoxItemsAdd();
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Bitte geben Sie gültige Zahlenwerte ein.");
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
