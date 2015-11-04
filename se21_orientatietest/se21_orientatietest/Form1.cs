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
                        adm.verkopen.Add(sd);
                        break;
                }
            }
            
            lbVerkopen.Items.Clear();
            foreach (Verkoop v in adm.verkopen)
            {
                lbVerkopen.Items.Add(v.ToString());
            }
        }
    }
}
