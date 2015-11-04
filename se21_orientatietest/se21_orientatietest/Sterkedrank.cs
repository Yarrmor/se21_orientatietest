using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol
{
    class Sterkedrank : Verkoop
    {
        public new BTWTarief BTWTarief { get { return BTWTarief; } }
        public new decimal Prijs { get { return Prijs; } }

        public Sterkedrank(int aantal)
            :base(aantal)
        {
            
        }

        public override string ToString()
        {
            return "Verkoop: Sterkedrank, aantal: " + this.Aantal;
        }
    }
}
