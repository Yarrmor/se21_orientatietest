using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol
{
    abstract class Verhuur : IInkomsten
    {
        public int UrenVerhuurd { get; set; }
        public decimal Bedrag { get { return Bedrag; } }
        public DateTime Tijdstip { get { return Tijdstip; } }
        public BTWTarief BTWTarief { get { return BTWTarief; } }
        public decimal PrijsPerUur { get { return PrijsPerUur; } }

        public Verhuur(DateTime tijdstip, int urenVerhuurd)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
