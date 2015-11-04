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
        public decimal Bedrag { get { return Bedrag; } }
        public DateTime Tijdstip { get { return Tijdstip; } }
        public BTWTarief BTWTarief { get { return BTWTarief; } }
        public decimal Prijs { get { return Prijs; } }
        
        public Verkoop(int aantal)
        {
            this.Aantal = aantal;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
