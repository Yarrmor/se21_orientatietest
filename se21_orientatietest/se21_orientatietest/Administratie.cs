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

        public List<IInkomsten> Overzicht(DateTime van, DateTime tot)
        {
            List<IInkomsten> overzicht = new List<IInkomsten>();
            List<IInkomsten> verhTemp = this.verhuringen.Cast<IInkomsten>().ToList();
            List<IInkomsten> verkTemp = this.verkopen.Cast<IInkomsten>().ToList();
            foreach(IInkomsten i in verkTemp)
            {
                verhTemp.Add(i);
            }
            var overzichtTemp = from v in verhTemp where (v.Tijdstip >= van && v.Tijdstip <= tot) orderby v.Tijdstip descending select v;
            foreach(IInkomsten o in overzichtTemp)
            {
                overzicht.Add(o);
            }
            return overzicht;
        }

        public List<IInkomsten> Overzicht(BTWTarief tarief)
        {
            List<IInkomsten> overzicht = new List<IInkomsten>();
            List<IInkomsten> verhTemp = this.verhuringen.Cast<IInkomsten>().ToList();
            List<IInkomsten> verkTemp = this.verkopen.Cast<IInkomsten>().ToList();
            foreach (IInkomsten i in verkTemp)
            {
                verhTemp.Add(i);
            }
            var overzichtTemp = from v in verhTemp where (v.BTWTarief == tarief) orderby v.Tijdstip descending select v;
            foreach (IInkomsten o in overzichtTemp)
            {
                overzicht.Add(o);
            }
            return overzicht;
        }
    }
}
