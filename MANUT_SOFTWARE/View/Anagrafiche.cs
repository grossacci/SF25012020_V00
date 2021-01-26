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
                .Where(p => p.Nome.Contains(textBox21.Text)).Select(p => new RepartoViewModel
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

            RepartoSQL.RepartoSQL_INSERT("REP-", textBox21.Text);

        }
        #endregion

        #region SALVA LINEA
        private void btn_Salva_Linea_Click(object sender, EventArgs e)
        {
            SQLServiceLinea LineaSQL = new SQLServiceLinea();
            List<LineaViewModel> LL = LineaSQL.LineaSQL_SELECT();
            List<LineaViewModel> LLF = LL
            .Where(p => p.Nome.Contains(textBox21.Text)).Select(p => new LineaViewModel
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

            LineaSQL.LineaSQL_INSERT("REP-", textBox21.Text);
        }
        #endregion
    }
}
