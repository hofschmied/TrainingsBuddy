using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Trainingscoach_Projekt
{
    public class GrundtrainingseinheitDaten
    {

        public string sessionName;
        public ComboBox grundEinheit;
        public GrundtrainingseinheitDaten()
        {
            this.sessionName = string.Empty;
            
        }

        public GrundtrainingseinheitDaten(string sessionName, ComboBox grundEinheit)
        {
            this.sessionName = sessionName;
            this.grundEinheit = grundEinheit;
        }

        public override string ToString()
        {
            return $"{sessionName}  ( {grundEinheit} )";
        }
    }
}
