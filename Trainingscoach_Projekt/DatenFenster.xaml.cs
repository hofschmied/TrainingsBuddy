using System;
using System.Windows;
using System.Windows.Controls;

namespace Trainingscoach_Projekt
{
    public partial class DatenFenster : Window
    {
        public nutzerEingabe nutzer;
        public Session einheiten;
        private ListBox uebungListBox;
        private MainWindow mainWindow;
        private static readonly Serilog.ILogger logger = LoggerClass.logger;

        public DatenFenster(Session einheiten, ListBox uebungListBox)
        {
            InitializeComponent();
            this.einheiten = einheiten;
            this.uebungListBox = uebungListBox;
            logger.Information("DatenFenster initialisiert");
        }

        private void ListBoxItemsAdd()
        {
            nutzer = new nutzerEingabe(einheitenName.Text, int.Parse(anzahlSets.Text), double.Parse(dauer.Text));
            einheiten.Einheiten.Add(nutzer);
            uebungListBox.Items.Clear();
            foreach (var item in einheiten.Einheiten)
            {
                uebungListBox.Items.Add(item);
            }
            logger.Information("Einheit hinzugefügt zur ListBox");
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
                logger.Information("Daten hinzugefügt und Fenster geschlossen");
            }
            catch (FormatException)
            {
                MessageBox.Show("Bitte geben Sie gültige Zahlenwerte ein.");
                logger.Error("Ungültige Zahlenwerte eingegeben");
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            logger.Information("Fenster geschlossen");
        }
    }
}
