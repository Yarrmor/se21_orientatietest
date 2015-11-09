using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol
{
    public abstract class Verhuur : IInkomsten
    {
        public int UrenVerhuurd { get; set; }
        public decimal Bedrag { get { return Bedrag; } set { Bedrag = this.PrijsPerUur * this.UrenVerhuurd; } }
        public DateTime Tijdstip { get; set; }
        public BTWTarief BTWTarief { get { return BTWTarief.Ongespecificeerd; } set { /* do nothing, really */ } }
        public decimal PrijsPerUur { get { return PrijsPerUur; } }

        public Verhuur(DateTime tijdstip, int urenVerhuurd)
        {
            this.Tijdstip = tijdstip;
            this.UrenVerhuurd = urenVerhuurd;
        }

        public override string ToString()
        {
            return "Verhuring: Feestzaal " + this.Tijdstip + " voor " + this.UrenVerhuurd + " uur.";
        }
    }
}
