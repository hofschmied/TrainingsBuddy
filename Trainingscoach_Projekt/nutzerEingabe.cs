using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Trainingscoach_Projekt;

    public class nutzerEingabe
    {
        public string einheitenName;
        public int anzahlSets;
        public double dauer;

        public void SekundenUmwandlung()
        {
            double dauerSekunden = dauer * 60;
        }

        public override string ToString()
        {
            return $"Übungsname: {einheitenName}, Anzahl Sets: {anzahlSets}, Dauer: {dauer} ";
        }
    
        public void Remove()
        {
            GanzKörperTrainingsFenster ganzKoerper = new GanzKörperTrainingsFenster();

            ListBox listBox = ganzKoerper.uebungListBox;
            if (listBox.SelectedItem != null)
            {
            listBox.Items.Remove(listBox.SelectedItem);
            }
        }

        public nutzerEingabe(string einheitenName, int anzahlSets, double dauer)
        {
           this.einheitenName = einheitenName;
           this.anzahlSets = anzahlSets;
           this.dauer = dauer;
        }

        public nutzerEingabe()
        {

        }

}
