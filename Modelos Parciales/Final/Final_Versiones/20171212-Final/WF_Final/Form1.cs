using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Entidades;

namespace WF_Final
{
    public partial class Form1 : Form
    {
        public List<Base> listaElementos;

        public Form1()
        {
            InitializeComponent();
            listaElementos = new List<Base>();
            Base.EventoBase += Manejador_Evento;
        }

        private void Manejador_Evento(List<Base> list)
        {
            string datos = "Cargados con el Evento:\n";
            foreach (Base a in list)
            {
                datos += a.MostrarVersion() + "\n";
            }
            CargarRichTextBox(datos);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Name = "Final - PabloDE";
            this.Text = this.Name;
        }

        private void btnPunto1_Click(object sender, EventArgs e)
        {
            Base derUno1 = new DerivadaUno(10, 11, 12);
            DerivadaUno derUno2 = new DerivadaUno(1, 2, 3);
            Base derDos1 = new DerivadaDos();

            listaElementos.Add(derUno1);
            listaElementos.Add(derUno2);
            listaElementos.Add(derDos1);

            // Generar el código para obtener todos los datos de los elementos de la lista y luego utilizar CargarRichTextBox para mostrarlos
            string auxiliar = "";

            foreach (Base b in listaElementos)
            {
                auxiliar += b.MostrarVersion() + "\n";
            }

            this.CargarRichTextBox(auxiliar);



        }

        delegate void CargarRichTextBoxCallback(string datos);
        private void CargarRichTextBox(string datos)
        {
            if (rtbTextoSalida.InvokeRequired)
            {
                CargarRichTextBoxCallback d = new CargarRichTextBoxCallback(CargarRichTextBox);
                this.Invoke(d, new object[] { datos });
            }
            else
            {
                // Código del alumno!!!!
                rtbTextoSalida.Text = datos;

            }
        }

        private void btnPunto2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solo primer parcial", "Solo primer parcial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnPunto3_Click(object sender, EventArgs e)
        {

        }

        private void btnPunto4_Click(object sender, EventArgs e)
        {

        }

        private void btnPunto5_Click(object sender, EventArgs e)
        {

        }


    }
}
