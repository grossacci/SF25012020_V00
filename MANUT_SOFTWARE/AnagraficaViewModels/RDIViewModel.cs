using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANUT_SOFTWARE.AnagraficaViewModels
{
    class RDIViewModel
    {

        //DATETIME
        public DateTime DataIns { get; set; }

        public DateTime OraInizio { get; set; }

        public DateTime OraFine { get; set; }

        public DateTime DataVerifica { get; set; }
        
        
        //BOOL 
        public bool EffSINO { get; set; }

        public bool ChiusoSINO { get; set; }


        //TESTO
        public string Macchina { get; set; }

        public string CodMacchina { get; set; }

        public string DescrizioneIntervento { get; set; }

        public string MaterialeImpiegato { get; set; }

        public string Note { get; set; }

        public string NomeCognomeOP { get; set; }

        public string FirmaOP { get; set; }

        public string FirmaRespManut { get; set; }


    }
}
