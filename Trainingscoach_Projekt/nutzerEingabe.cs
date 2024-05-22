using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainingscoach_Projekt
{
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
            return $"{einheitenName}, {anzahlSets}, {dauer} ";
        }
    }

}
