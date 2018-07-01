﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio69
{
    public partial class frmTestDelegados : Form
    {
        public delegate void Delegado(string a);
        public event Delegado actualizado;

        public frmTestDelegados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.actualizado(textBox1.Text);
        }
    }
}
