using System;
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
    public partial class frmPrincipal : Form
    {
        frmTestDelegados formTestDelegados;

        public frmPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        private void testDelegadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTestDelegados = new frmTestDelegados();
            formTestDelegados.Owner = this;
            formTestDelegados.StartPosition = FormStartPosition.CenterScreen;
            formTestDelegados.Show();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatos formDatos = new frmDatos();
            formDatos.Owner = this;
            formDatos.StartPosition = FormStartPosition.CenterScreen;
            formDatos.Show();

            formTestDelegados.actualizado += formDatos.ActualizarNombre;
        }
    }
}
