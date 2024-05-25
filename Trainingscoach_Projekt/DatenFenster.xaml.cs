using System;
using System.Windows;

namespace Trainingscoach_Projekt
{
    public partial class DatenFenster : Window
    {
        public nutzerEingabe nutzer;

        public DatenFenster()
        {
            InitializeComponent();
        }

        private void ListBoxItemsAdd()
        {
            nutzer = new nutzerEingabe(einheitenName.Text, int.Parse(anzahlSets.Text), double.Parse(dauer.Text));
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
    }
}
