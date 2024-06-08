using System;
using System.Windows;
using System.Windows.Threading;

namespace Trainingscoach_Projekt
{
    public partial class QuestFenster : Window
    {
        private DispatcherTimer dispatcherTimer;
        private DateTime naechsteUebung;
        HauptprogrammTimer timer;

        public QuestFenster()
        {
            InitializeComponent();
            AktualisierungsTimer();
        }

        private void AktualisierungsTimer()
        {
            naechsteUebung = DateTime.Now.AddHours(24);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan zeit = naechsteUebung - DateTime.Now;
            if (zeit > TimeSpan.Zero)
            {
                NextExerciseTime.Text = $"Nächste Aufgaben in: {zeit:hh\\:mm\\:ss}";
            }
            else
            {
                NextExerciseTime.Text = "Nächste Aufgaben in: 00:00:00";
                dispatcherTimer.Stop();
            }
        }
    }
}
