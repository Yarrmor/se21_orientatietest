using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol
{
    class Administratie
    {
        public List<Verhuur> verhuringen;
        public List<Verkoop> verkopen;

        public Administratie()
        {
            this.verhuringen = new List<Verhuur>();
            this.verkopen = new List<Verkoop>();
        }

        public void VoegToe(Verhuur verhuur)
        {
            this.verhuringen.Add(verhuur);
        }

        public void VoegToe(Verkoop verkoop)
        {
            this.verkopen.Add(verkoop);
        }
    }
}
