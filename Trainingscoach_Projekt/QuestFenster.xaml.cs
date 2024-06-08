using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.TextFormatting;
using System.Windows.Threading;

namespace Trainingscoach_Projekt
{
    public partial class QuestFenster : Window
    {
        private DispatcherTimer dispatcherTimer;
        private DateTime naechsteUebung;
        List<bool> validList;
        List<CheckBox> checkBoxen = new List<CheckBox>();

        public QuestFenster(List<bool> validList)
        {
            InitializeComponent();
            this.checkBoxen.Add(aufgabe1);
            this.checkBoxen.Add(aufgabe2);
            this.checkBoxen.Add(aufgabe3);
            this.checkBoxen.Add(aufgabe4);
            this.checkBoxen.Add(aufgabe5);
            this.validList = validList;
            questErledigt();
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

        private void questErledigt()
        {
            for (int i = 0; i < validList.Count; i++)
            {
                checkBoxen[i].IsChecked = validList[i];
            }
        }
    }
}
