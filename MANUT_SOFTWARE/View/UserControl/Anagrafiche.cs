using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MANUT_SOFTWARE.Service;
using MANUT_SOFTWARE.ViewModels;
using MANUT_SOFTWARE.Anagrafica_Service;

namespace MANUT_SOFTWARE
{
    public partial class AnagraficaMacchine : UserControl
    {
        public AnagraficaMacchine()
        {
            InitializeComponent();

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }


        #region SALVA REPARTO
        private void btn_Salva_Reparto_Click(object sender, EventArgs e)
        {
                SQLServiceReparto RepartoSQL = new SQLServiceReparto();
                List<RepartoViewModel> LP =  RepartoSQL.RepartoSQL_SELECT();
                List<RepartoViewModel> LPF= LP
                .Where(p => p.Nome == (txReparto_Nom.Text)).Select(p => new RepartoViewModel
                {
                    ID = p.ID,
                    Codice = p.Codice,
                    Nome = p.Nome
                }).ToList();
             if (LPF.Any())
                {
                MessageBox.Show("Attenzione, Hai già inserito il reparto!","Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
                }

            RepartoSQL.RepartoSQL_INSERT("REP-", txReparto_Nom.Text);
            CaricaCbMacchine_Reparto();
            CaricaCbMacchine_Linea();
            CaricaCbMacchine_RepartoAss();
        }
        #endregion

        #region SALVA LINEA
        private void btn_Salva_Linea_Click(object sender, EventArgs e)
        {
            SQLServiceLinea LineaSQL = new SQLServiceLinea();
            List<LineaViewModel> LL = LineaSQL.LineaSQL_SELECT();
            List<LineaViewModel> LLF = LL
            .Where(p => p.Nome == (txLinea_Nom.Text)).Select(p => new LineaViewModel
            {
                ID = p.ID,
                Codice = p.Codice,
                Nome = p.Nome
            }).ToList();
            if (LLF.Any())
            {
                MessageBox.Show("Attenzione, Hai già inserito il reparto!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SQLServiceReparto SQLService = new SQLServiceReparto();
            List<RepartoViewModel> R = new List<RepartoViewModel>();
            R = SQLService.RepartoSQL_SELECT()
                .Where(P => P.Nome.Contains(cbLinea_RepAss.Text.Remove(0,7)))
                .Select(P => new RepartoViewModel
            {
                Codice = P.Codice,
                ID = P.ID

            }).ToList();
            foreach(RepartoViewModel r in R)
            LineaSQL.LineaSQL_INSERT("LIN-", txLinea_Nom.Text,r.Codice+r.ID);
            CaricaCbMacchine_Linea();
        }
        #endregion
        
        #region SALVA MACCHINA
        private void btn_Salva_Macchina_Click(object sender, EventArgs e)
        {
            SQLServiceMacchina MacchinaSQL= new SQLServiceMacchina();
            List<MacchineViewModel> LM = MacchinaSQL.MacchinaSQL_SELECT();
            List<MacchineViewModel> LMF = LM
            .Where(p => p.Denominazione == (txMacchina_Denom.Text)).Select(p => new MacchineViewModel
            {
                Denominazione= p.Denominazione
            }).ToList();

            if (LMF.Any())
            {
                MessageBox.Show("Attenzione, Hai già inserito il reparto!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            {
               
                    MacchinaSQL.MacchinaSQL_INSERT("MAC-" ,txMacchina_Forn.Text, Convert.ToInt32(txMacchina_DataArr.Text), txMacchina_Denom.Text, cbMacchina_Rep.Text.Remove(5), cbMacchina_Lin.Text.Remove(5), txMacchina_Tarat.Text, txMacchina_Manut.Text, txMacchina_Verific.Text, cbMacchine_Dism.Text , txMacchina_Mod.Text, txMacchina_Matric.Text, Convert.ToInt32(txMacchina_AndiCostr.Text));
                
            }
        }
        #endregion 


        #region CARICAMENTO DEI CB



        public void CaricaCbMacchine_Dismiss()
        {
                ComboBoxService C = new ComboBoxService();
                foreach(string S in C.CboxDismissione)
                cbMacchine_Dism.Items.Add(S);
                cbMacchine_Dism.SelectedIndex = 0;
        }


        public void CaricaCbMacchine_Reparto()
        {
         //   cbMacchina_Rep.Items.Clear();
            ComboBoxService C = new ComboBoxService();
            foreach (RepartoViewModel R in C.ServiceRepartoSELECT())
            {
                        cbMacchina_Rep.Items.Add(R.Codice + R.ID + ": " + R.Nome);
            }
            
               try
            {
                cbMacchina_Rep.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException e)
            {
                //MessageBox.Show(e.ToString());
            }
           
        }

        private void cbMacchina_Rep_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CaricaCbMacchine_Linea();
        }



        public void CaricaCbMacchine_RepartoAss()
        {
            cbLinea_RepAss.Items.Clear();
            ComboBoxService C = new ComboBoxService();
            foreach (RepartoViewModel R in C.ServiceRepartoSELECT())
               cbLinea_RepAss.Items.Add(R.Codice + R.ID + ": " + R.Nome);
            try
            {
                cbLinea_RepAss.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException e)
            { MessageBox.Show(e.ToString()); }

        }

        public void CaricaCbMacchine_Linea()
        {
            cbMacchina_Lin.Items.Clear();

            ComboBoxService C = new ComboBoxService();
            SQLServiceReparto SQLService = new SQLServiceReparto();

         
            foreach (LineaViewModel L in C.ServiceLineaSELECT().Where(P => P.RepartoAssociato == cbMacchina_Rep.Text.Remove(5)).Select(P => new LineaViewModel { ID = P.ID, Codice = P.Codice, Nome = P.Nome, RepartoAssociato = P.RepartoAssociato }).ToList())
            cbMacchina_Lin.Items.Add(L.Codice + L.ID + ": " + L.Nome);
            if (cbMacchina_Lin.Items.Count > 0)
            {
                cbMacchina_Lin.Visible = true;
                try
                {
                    cbMacchina_Lin.SelectedIndex = 0;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            else if (cbMacchina_Lin.Items.Count == 0)
            {
                cbMacchina_Lin.Visible = false;
            }
        }




        #endregion

        private void cercaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CercaMacchineForm CR = new CercaMacchineForm();
            CR.Show();


        }
    }
}
