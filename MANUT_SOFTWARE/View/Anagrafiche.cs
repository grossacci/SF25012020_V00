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

        }
        #endregion

        #region SALVA LINEA
        private void btn_Salva_Linea_Click(object sender, EventArgs e)
        {
            SQLServiceLinea LineaSQL = new SQLServiceLinea();
            List<LineaViewModel> LL = LineaSQL.LineaSQL_SELECT();
            List<LineaViewModel> LLF = LL
            .Where(p => p.Nome == (txReparto_Nom.Text)).Select(p => new LineaViewModel
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

            LineaSQL.LineaSQL_INSERT("LIN-", txLinea_Nom.Text);
        }
        #endregion

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
               
                    MacchinaSQL.MacchinaSQL_INSERT("MAC-", txMacchina_Cod.Text, Convert.ToDateTime(txMacchina_DataArr.Text), txMacchina_Denom.Text, cbMacchina_Rep.Text, cbMacchina_Lin.Text, txMacchina_Tarat.Text, txMacchina_Manut.Text, txMacchina_Verific.Text, cbMacchine_Dism.Text , txMacchina_Mod.Text, txMacchina_Matric.Text, Convert.ToDateTime(txMacchina_AnnoDiCostr));
                
                  
            }
        }
    }
}
