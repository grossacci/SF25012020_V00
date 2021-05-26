using MANUT_SOFTWARE.Service;
using MANUT_SOFTWARE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MANUT_SOFTWARE.Anagrafica_Service
{
    class ComboBoxService
    {
        public List<string> CboxDismissione = new List<string> { "NON DISMESSO", "DISMESSO" };

        public  List<RepartoViewModel> ServiceRepartoSELECT()
        {
            SQLServiceReparto SQLService = new SQLServiceReparto();
            List<RepartoViewModel> L = new List<RepartoViewModel>();
            L = SQLService.RepartoSQL_SELECT();
            return L;
        }


        public List<LineaViewModel> ServiceLineaSELECT()
        {
            SQLServiceLinea SQLService = new SQLServiceLinea();
            List<LineaViewModel> L = new List<LineaViewModel>();
            L = SQLService.LineaSQL_SELECT();
            return L;
        }
    }
}
