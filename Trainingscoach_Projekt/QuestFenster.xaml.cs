using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Serilog;

namespace Trainingscoach_Projekt
{
    public partial class QuestFenster : Window
    {
        private DispatcherTimer dispatcherTimer;
        private DateTime nextExercise;
        private List<bool> validList;
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private static readonly ILogger logger = LoggerClass.logger;

        public QuestFenster(List<bool> validList)
        {
            InitializeComponent();
            this.checkBoxes.Add(aufgabe1);
            this.checkBoxes.Add(aufgabe2);
            this.checkBoxes.Add(aufgabe3);
            this.checkBoxes.Add(aufgabe4);
            this.checkBoxes.Add(aufgabe5);
            this.validList = validList;
            logger.Information("QuestFenster initialisiert");
            questErledigt();
            AktualisierungsTimer();
        }

        private void AktualisierungsTimer()
        {
            nextExercise = DateTime.Now.AddHours(24);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
            logger.Information("Aktualisierungs-Timer gestartet");
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeLeft = nextExercise - DateTime.Now;
            if (timeLeft > TimeSpan.Zero)
            {
                NextExerciseTime.Text = $"Nächste Aufgaben in: {timeLeft:hh\\:mm\\:ss}";
            }
            else
            {
                NextExerciseTime.Text = "Nächste Aufgaben in: 00:00:00";
                dispatcherTimer.Stop();
                logger.Information("Aktualisierungs-Timer gestoppt");
            }
        }

        private void questErledigt()
        {
            for (int i = 0; i < validList.Count; i++)
            {
                checkBoxes[i].IsChecked = validList[i];
            }
            logger.Information("Quests aktualisiert");
        }
    }
}
