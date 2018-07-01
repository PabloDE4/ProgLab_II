using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio20;

namespace Ejercicio23_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnConverEuro_Click(object sender, EventArgs e)
        {
            Euro euro = new Euro(Double.Parse(txtEuro.Text));
            Dolar dolar = new Dolar(Double.Parse(txtEuro.Text));
            Pesos pesos = new Pesos(Double.Parse(txtEuro.Text));

            txtEuroAEuro.Text = Math.Round(euro.GetCantidad(), 2).ToString();
            txtEuroAEuro.ReadOnly = true;

            dolar = (Dolar)euro;
            txtEuroADolar.Text = Math.Round(dolar.GetCantidad(), 2).ToString();
            txtEuroADolar.ReadOnly = true;

            pesos = (Pesos)dolar;
            txtEuroAPesos.Text = Math.Round(pesos.GetCantidad(), 2).ToString();
            txtEuroAPesos.ReadOnly = true;

        }

        private void btnConverDolar_Click(object sender, EventArgs e)
        {
            Euro euro = new Euro(Double.Parse(txtDolar.Text));
            Dolar dolar = new Dolar(Double.Parse(txtDolar.Text));
            Pesos pesos = new Pesos(Double.Parse(txtDolar.Text));


            euro = (Euro)dolar;
            txtDolarADolar.Text = Math.Round(dolar.GetCantidad(), 2).ToString();
            txtDolarADolar.ReadOnly = true;

            txtDolarAEuro.Text = Math.Round(euro.GetCantidad(), 2).ToString();
            txtDolarAEuro.ReadOnly = true;

            pesos = (Pesos)dolar;
            txtDolarAPesos.Text = Math.Round(pesos.GetCantidad(), 2).ToString();
            txtDolarAPesos.ReadOnly = true;
        }

        private void btnConverPesos_Click(object sender, EventArgs e)
        {
            Euro euro = new Euro(Double.Parse(txtPesos.Text));
            Dolar dolar = new Dolar(Double.Parse(txtPesos.Text));
            Pesos pesos = new Pesos(Double.Parse(txtPesos.Text));


            txtPesosAPesos.Text = Math.Round(pesos.GetCantidad(), 2).ToString();
            txtPesosAPesos.ReadOnly = true;

            euro = (Euro)pesos;
            txtPesosAEuro.Text = Math.Round(euro.GetCantidad(), 2).ToString();
            txtPesosAEuro.ReadOnly = true;

            dolar = (Dolar)pesos;
            txtPesosADolar.Text = Math.Round(dolar.GetCantidad(), 2).ToString();
            txtPesosADolar.ReadOnly = true;
        }
    }
}
