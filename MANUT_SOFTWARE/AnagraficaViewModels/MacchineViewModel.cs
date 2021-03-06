﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANUT_SOFTWARE.ViewModels
{
    class MacchineViewModel
    {

        public int ID { get; set; }

        public int Identificativo { get; set; }

        public string Codice { get; set; }

        public DateTime DataArrivo { get; set; }

        public string Denominazione { get; set; }

        public string Reparto { get; set; }

        public string Linea { get; set; }

        public string Taratura { get; set; }

        public string Manutenzione { get; set; }

        public string Verifica { get; set; }

        public bool Dismissione { get; set; }

        public string Modello { get; set; }

        public string Matricola { get; set; }

        public DateTime AnnoDiCostruzione { get; set; }

        public Image  Immagine { get; set; }   //da verificare formato!!

    }
}
