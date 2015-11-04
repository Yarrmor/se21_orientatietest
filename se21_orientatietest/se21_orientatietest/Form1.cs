using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jelle_Grol
{
    public partial class Form1 : Form
    {
        Administratie adm;

        public Form1()
        {
            InitializeComponent();

            adm = new Administratie();
        }

        private void btnNieuweVerhuringToevoegen_Click(object sender, EventArgs e)
        {
            int verhuurType = cbNieuweVerhuring.SelectedIndex;

            if (nudNieuweVerhuringUren.Value > 0 && dtpNieuweVerhuringTijdstip.Value >= DateTime.Now)
            {
                //TODO: Add more types
                switch (verhuurType)
                {
                    case 0:
                        Feestzaal fz = new Feestzaal(dtpNieuweVerhuringTijdstip.Value, Convert.ToInt16(nudNieuweVerhuringUren.Value));
                        adm.VoegToe(fz);
                        break;
                }
            }

            lbVerhuringen.Items.Clear();
            foreach(Verhuur v in adm.verhuringen)
            {
                lbVerhuringen.Items.Add(v.ToString());
            }
        }

        private void btnNieuweVerkoopToevoegen_Click(object sender, EventArgs e)
        {
            int verkoopType = cbNieuweVerkoop.SelectedIndex;

            if (nudNieuweVerkoopAantal.Value > 0)
            {
                //TODO: Add more types
                switch (verkoopType)
                {
                    case 0:
                        Sterkedrank sd = new Sterkedrank(Convert.ToInt16(nudNieuweVerkoopAantal.Value));
                        adm.VoegToe(sd);
                        break;
                }
            }
            
            lbVerkopen.Items.Clear();
            foreach (Verkoop v in adm.verkopen)
            {
                lbVerkopen.Items.Add(v.ToString());
            }
        }

        private void btnOverzichtDatumbereik_Click(object sender, EventArgs e)
        {
            List<IInkomsten> overzicht = adm.Overzicht(dtpOverzichtVan.Value, dtpOverzichtTot.Value);
            List<string> stringList = new List<string>();
            decimal totaalPrijs = 0.0M;
            foreach(IInkomsten i in overzicht)
            {
                stringList.Add(i.ToString());
                //totaalPrijs = totaalPrijs + i.Bedrag;
            }
            stringList.Add("Totaalprijs: " + totaalPrijs.ToString());
            //BRON: http://stackoverflow.com/questions/5163108/how-do-i-put-the-contents-of-a-list-in-a-single-messagebox
            var message = string.Join(Environment.NewLine, stringList);
            MessageBox.Show(message);
        }

        private void cbOverzichtBTW_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = cbOverzichtBTW.SelectedIndex;
            List<IInkomsten> overzicht = new List<IInkomsten>();

            switch(type)
            {
                case 0:
                    overzicht = adm.Overzicht(BTWTarief.Ongespecificeerd);
                    break;
                case 1:
                    overzicht = adm.Overzicht(BTWTarief.Hoog);
                    break;
                case 2:
                    overzicht = adm.Overzicht(BTWTarief.Laag);
                    break;
            }

            List<string> stringList = new List<string>();
            decimal totaalPrijs = 0.0M;
            foreach (IInkomsten i in overzicht)
            {
                stringList.Add(i.ToString());
                //totaalPrijs = totaalPrijs + i.Bedrag;
            }
            stringList.Add("Totaalprijs: " + totaalPrijs.ToString());
            //BRON: http://stackoverflow.com/questions/5163108/how-do-i-put-the-contents-of-a-list-in-a-single-messagebox
            var message = string.Join(Environment.NewLine, stringList);
            MessageBox.Show(message);
        }

        private void btnOverzichtExporteer_Click(object sender, EventArgs e)
        {
            int type = cbOverzichtBTW.SelectedIndex;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = fbd.SelectedPath;

                switch (type)
                {
                    case 0:
                        adm.Exporteer(path, BTWTarief.Ongespecificeerd);
                        break;
                    case 1:
                        adm.Exporteer(path, BTWTarief.Laag);
                        break;
                    case 2:
                        adm.Exporteer(path, BTWTarief.Hoog);
                        break;
                }
            }
        }
    }
}
