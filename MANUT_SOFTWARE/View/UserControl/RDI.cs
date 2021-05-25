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
            
        }
    }
}
