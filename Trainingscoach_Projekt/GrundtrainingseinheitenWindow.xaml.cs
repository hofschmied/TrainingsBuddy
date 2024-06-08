using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Trainingscoach_Projekt
{
    public partial class GrundtrainingseinheitenWindow : Window
    {
        GrundtrainingseinheitDaten grundtrainingseinheitDaten;
        private static readonly Serilog.ILogger logger = LoggerClass.logger;

        public string uebergabeText { get; set; }

        public List<string> strings = new List<string>();

        public GrundtrainingseinheitenWindow()
        {
            InitializeComponent();
            logger.Information("GrundtrainingseinheitenWindow initialisiert");
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            try
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

                    this.uebergabeText = grundtrainingseinheitDaten.sessionName + "-|~#+*" + selectedGrundEinheit;

                    strings.Add(grundtrainingseinheitDaten.sessionName);

                    this.Close();
                    logger.Information("GrundtrainingseinheitenWindow geschlossen");
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie eine Grund-Trainingseinheit aus.");
                    logger.Warning("Keine Grund-Trainingseinheit ausgewählt");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fehler beim Klicken des OK-Buttons.");
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
                logger.Error(ex, "Fehler beim Bewegen des Fensters.");
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
            logger.Information("GrundtrainingseinheitenWindow geschlossen");
        }
    }
}
