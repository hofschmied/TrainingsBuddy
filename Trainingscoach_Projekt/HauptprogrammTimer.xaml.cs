using System;
using System.Windows;
using System.Windows.Threading;

namespace Trainingscoach_Projekt
{
    public partial class HauptprogrammTimer : Window
    {
        private DispatcherTimer timer;
        private TimeSpan time;

        public HauptprogrammTimer()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(laengeEinheit.Text, out int minutes) && minutes > 0)
            {
                time = TimeSpan.FromMinutes(minutes);
                TimerProgressBar.Maximum = time.TotalSeconds;
                TimerProgressBar.Value = time.TotalSeconds;
                timer.Start();
            }
            else
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zeit in Minuten ein.", "Ungültige Eingabe", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            TimerTextBlock.Text = "00:00";
            TimerProgressBar.Value = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time.TotalSeconds > 0)
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                TimerTextBlock.Text = time.ToString("mm\\:ss");
                TimerProgressBar.Value = time.TotalSeconds;
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Zeit abgelaufen!", "Timer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_Spotify(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://open.spotify.com/");
        }

        private void Window_MausRunter(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }
    }
}