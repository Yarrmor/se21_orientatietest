using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol
{
    abstract class Verkoop : IInkomsten
    {
        public int Aantal { get; set; }
        public decimal Bedrag { get { return this.Bedrag; } set { Bedrag = this.Prijs * this.Aantal; } }
        public DateTime Tijdstip { get; set; }
        public BTWTarief BTWTarief { get { return BTWTarief; } set { BTWTarief = BTWTarief.Ongespecificeerd; } }
        public decimal Prijs { get { return Prijs; } }
        
        public Verkoop(int aantal)
        {
            this.Aantal = aantal;
            this.Tijdstip = DateTime.Now;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
