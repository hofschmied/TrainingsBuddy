using System;
using System.Collections.Generic;

namespace Trainingscoach_Projekt
{
    public class Session
    {
        public string Name { get; set; }
        public string Grundeinheit { get; set; }
        public List<string> Einheiten = new List<string>();

        public Session(string uebergabetext)
        {
            Einheiten = new List<string>();
            this.Name = uebergabetext;
        }
    }
}
