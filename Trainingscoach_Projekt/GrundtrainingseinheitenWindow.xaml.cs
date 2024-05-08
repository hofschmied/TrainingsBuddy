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

namespace Trainingscoach_Projekt
{
    /// <summary>
    /// Interaction logic for GrundtrainingseinheitenWindow.xaml
    /// </summary>
    public partial class GrundtrainingseinheitenWindow : Window
    {
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
    }
}
