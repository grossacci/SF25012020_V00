﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MANUT_SOFTWARE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void anagraficaMacchine1_Load(object sender, EventArgs e)
        {
            anagraficaMacchine1.CaricaCbMacchine_Dismiss();

        }
    }
}
