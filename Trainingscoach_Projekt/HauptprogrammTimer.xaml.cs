using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Trainingscoach_Projekt
{
    public partial class HauptprogrammTimer : Window
    {
        private DispatcherTimer timer;
        private TimeSpan time;
        private double totalSeconds;

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
                totalSeconds = time.TotalSeconds;
                TimerTextBlock.Text = time.ToString("mm\\:ss");
                timer.Start();
                UpdateProgressPath(1); // Set initial progress to 100%
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
            UpdateProgressPath(0); // Reset progress path
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time.TotalSeconds > 0)
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                TimerTextBlock.Text = time.ToString("mm\\:ss");
                double percentage = time.TotalSeconds / totalSeconds;
                UpdateProgressPath(percentage);
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Zeit abgelaufen!", "Timer", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateProgressPath(0); // Reset progress path
            }
        }

        private void UpdateProgressPath(double percentage)
        {
            double angle = 360 * percentage;
            double radians = (Math.PI / 180) * angle;
            double x = 100 + 90 * Math.Cos(radians - Math.PI / 2);
            double y = 100 + 90 * Math.Sin(radians - Math.PI / 2);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(100, 10);

            ArcSegment arcSegment = new ArcSegment();
            arcSegment.Point = new Point(x, y);
            arcSegment.Size = new Size(90, 90);
            arcSegment.SweepDirection = SweepDirection.Clockwise;
            arcSegment.IsLargeArc = angle >= 180.0;

            PathGeometry pathGeometry = new PathGeometry();
            pathFigure.Segments.Add(arcSegment);
            pathGeometry.Figures.Add(pathFigure);

            progressPath.Data = pathGeometry;
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
