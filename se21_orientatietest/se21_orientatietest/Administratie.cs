using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void Exporteer(string path, BTWTarief tarief)
        {
            List<IInkomsten> overzicht = new List<IInkomsten>();
            List<IInkomsten> verhTemp = this.verhuringen.Cast<IInkomsten>().ToList();
            List<IInkomsten> verkTemp = this.verkopen.Cast<IInkomsten>().ToList();
            foreach (IInkomsten i in verkTemp)
            {
                verhTemp.Add(i);
            }
            var overzichtTemp = from v in verhTemp where (v.BTWTarief == tarief) orderby v.Tijdstip descending select v;
            List<string> stringList = new List<string>();
            foreach(IInkomsten i in overzichtTemp)
            {
                stringList.Add(i.ToString());
            }

            //BRON: https://msdn.microsoft.com/en-us/library/system.io.file.createtext(v=vs.110).aspx
            if (!File.Exists(path + "test.txt"))
            {
                using (StreamWriter sw = File.CreateText(path + "test.txt"))
                {
                    foreach (string s in stringList)
                    {
                        sw.WriteLine(s);
                    }
                }
            }
        }
    }
}
