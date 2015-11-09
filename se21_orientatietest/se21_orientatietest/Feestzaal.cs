using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol
{
    public class Feestzaal : Verhuur
    {
        public new BTWTarief BTWTarief { get { return BTWTarief; } set { BTWTarief = BTWTarief.Hoog; } }
        public new decimal PrijsPerUur { get { return PrijsPerUur; } set { PrijsPerUur = 10.0M; } }

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
