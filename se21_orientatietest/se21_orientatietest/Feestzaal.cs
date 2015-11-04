using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol
{
    class Feestzaal : Verhuur
    {
        public new BTWTarief BTWTarief { get { return BTWTarief; } }
        public new decimal PrijsPerUur { get { return PrijsPerUur; } }

        public Feestzaal(DateTime tijdstip, int urenVerhuurd)
            :base(tijdstip, urenVerhuurd)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
