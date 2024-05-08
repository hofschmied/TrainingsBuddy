using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Trainingscoach_Projekt
{
    public class GrundtrainingseinheitDaten
    {

        public string sessionName;
        public string grundEinheit;
        public GrundtrainingseinheitDaten()
        {
            this.sessionName = string.Empty;
            this.grundEinheit = string.Empty;
        }

        public GrundtrainingseinheitDaten(string sessionName, string grundEinheit)
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
