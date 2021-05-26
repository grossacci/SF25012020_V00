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
using MANUT_SOFTWARE.RDIViewModels;
using MANUT_SOFTWARE.RDI_Service.SQL;

namespace MANUT_SOFTWARE
{
    public partial class RDI : UserControl
    {
        public RDI()
        {
            InitializeComponent();
        }

        private void btn_Salva_RDI_Click(object sender, EventArgs e)
        {

            RDIViewModel RDI = new RDIViewModel();
            SQLServiceRDI RDISQL = new SQLServiceRDI();

            DialogResult Result =     MessageBox.Show("Sei veramente sicuro di salvare le modifiche?", "Conferma", MessageBoxButtons.YesNoCancel);

            if (Result == DialogResult.Yes)
            RDISQL.RDISQL_INSERT("RDI-", Convert.ToDateTime(mtxRDI_DataIns.Text), Convert.ToDateTime(mtxRDI_OraInizio.Text), Convert.ToDateTime(mtxRDI_OraFine.Text), Convert.ToDateTime(mtxRDI_DataVerifica.Text), ckRDI_EffSI.Checked, ckRDI_ChiusoSI.Checked, txRDI_Macc.Text, txRDI_CodMacc.Text, txRDI_Descr.Text, txRDI_MatImp.Text, txRDI_Note.Text, txRDI_NomeCognomeOP.Text, txRDI_FirmaOP.Text, txRDI_FirmaRespManut.Text);

            else if (Result == DialogResult.No)
                return;            
        
        }
    }
}
