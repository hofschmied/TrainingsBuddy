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
            
            this.Name = uebergabetext.Split(" ")[0];
        }

        public override string ToString()
        {
            return $"{Name}, {Grundeinheit}";
        }
    }
}
