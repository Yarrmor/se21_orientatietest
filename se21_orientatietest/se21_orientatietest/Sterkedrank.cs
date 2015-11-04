using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol
{
    class Sterkedrank : Verkoop
    {
        public new BTWTarief BTWTarief { get { return BTWTarief; } set { BTWTarief = BTWTarief.Hoog; } }
        public new decimal Prijs { get { return Prijs; } set { Prijs = 10.0M; } }

        public Sterkedrank(int aantal)
            :base(aantal)
        {
            
        }

        public override string ToString()
        {
            return "Verkoop: Sterkedrank, aantal: " + this.Aantal + "+ om " + this.Tijdstip.ToString();
        }
    }
}
