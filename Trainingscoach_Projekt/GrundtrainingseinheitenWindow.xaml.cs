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

namespace Trainingscoach_Projekt
{
    /// <summary>
    /// Interaction logic for GrundtrainingseinheitenWindow.xaml
    /// </summary>
    public partial class GrundtrainingseinheitenWindow : Window
    {
        MainWindow mainWindow;

        public string uebergabeText { get; set; }

        public GrundtrainingseinheitenWindow()
        {
            InitializeComponent();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event here
        }

        private void TextBoxTrainingsName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FachBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.uebergabeText= TextBoxTrainingsName.Text.ToString();
            ComboBoxItem selectedItem = (ComboBoxItem)GrundTrainingsEinheitBox.SelectedItem;
            uebergabeText += " (" + selectedItem.Content.ToString() + ")";
           
            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
