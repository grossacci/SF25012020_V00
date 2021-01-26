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

        private void btn_Salva_Reparto_Click(object sender, EventArgs e)
        {
            SQLServiceLinea InsertLinea = new SQLServiceLinea();

            InsertLinea.Insert_INTO(textBox22.Text, textBox21.Text);
         


        }
    }
}
