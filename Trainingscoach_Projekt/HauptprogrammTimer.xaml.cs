using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for HauptprogrammTimer.xaml
    /// </summary>
    public partial class HauptprogrammTimer : Window
    {
        public HauptprogrammTimer()
        {
            InitializeComponent();
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

        private void Button_Click_Spotify(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("C:\\Program Files\\WindowsApps\\SpotifyAB.SpotifyMusic_1.238.720.0_x64__zpdnekdrzrea0\\Spotify.exe");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Spotify konnte nicht geöffnet werden: " + ex.Message);
            }
        }
    }
}
