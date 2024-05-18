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
    /// Interaction logic for BauchTrainingsFenster.xaml
    /// </summary>
    public partial class BauchTrainingsFenster : Window
    {
        public BauchTrainingsFenster()
        {
            InitializeComponent();
        }

        private void info_button_crunches(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Crunches, klein aber fein. ");
        }
    }
}
