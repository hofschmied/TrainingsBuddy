using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Serilog;
using System.IO;
using System.Text.Json;

namespace Trainingscoach_Projekt
{
    public partial class QuestFenster : Window
    {
        private DispatcherTimer dispatcherTimer;
        private DateTime nextExercise;
        private List<bool> validList;
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private static readonly ILogger logger = LoggerClass.logger;
        private const string filePath = "questStatus.json";

        public QuestFenster(List<bool> validList)
        {
            InitializeComponent();
            this.checkBoxes.Add(aufgabe1);
            this.checkBoxes.Add(aufgabe2);
            this.checkBoxes.Add(aufgabe3);
            this.checkBoxes.Add(aufgabe4);
            this.checkBoxes.Add(aufgabe5);
            this.validList = validList ?? new List<bool> { false, false, false, false, false };
            QuestLaden();
            logger.Information("QuestFenster initialisiert");
            questErledigt();
        }

        private void AktualisierungsTimer()
        {
            nextExercise = DateTime.Now.AddHours(24);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
            logger.Information("Aktualisierungs-Timer gestartet");
        }

        private void questErledigt()
        {
            for (int i = 0; i < validList.Count; i++)
            {
                checkBoxes[i].IsChecked = validList[i];
            }
            logger.Information("Quests aktualisiert");
        }

        public void QuestSpeichern()
        {
            List<bool> states = new List<bool>();
            foreach (var checkBox in checkBoxes)
            {
                states.Add(checkBox.IsChecked ?? false);
            }
            string json = JsonSerializer.Serialize(states);
            File.WriteAllText(filePath, json);
            logger.Information("Quest-Zustand gespeichert");
        }

        private void QuestLaden()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                validList = JsonSerializer.Deserialize<List<bool>>(json);
                if (validList.Count != checkBoxes.Count)
                {
                    validList = new List<bool> { false, false, false, false, false };
                }
                questErledigt();
                logger.Information("Quest-Zustand geladen");
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            QuestSpeichern();
        }
    }
}
