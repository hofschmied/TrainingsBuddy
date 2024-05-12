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
    /// Interaction logic for AuswaehlenSpezifischeUebungFenster.xaml
    /// </summary>
    public partial class AuswaehlenSpezifischeUebungFenster : Window
    {
        public ListBox listBox;
        public AuswaehlenSpezifischeUebungFenster(ListBox listBox)
        {
            InitializeComponent();
            this.listBox = listBox;
        }
    }
}
