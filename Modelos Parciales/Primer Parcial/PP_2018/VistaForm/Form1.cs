using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VistaForm
{
    public partial class frmVista : Form
    {
        private Curso curso;

        public Curso Curso
        {
            get
            {
                return curso;
            }
            set
            {
                curso = value;
            }
        }

        public frmVista()
        {
            InitializeComponent();
        }

        private void btnCrearCurso_Click(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(this.curso, null))
            {
                MessageBox.Show("Debe agregar datos validos");
                return;
            }

            Divisiones division;
            short anio = (short)nudAnio.Value;
            Enum.TryParse<Divisiones>(cmbDivisionCurso.SelectedValue.ToString(), out division);
            Profesor profesor = new Profesor(txtNombreProfe.Text, txtApellidoProfe.Text, txtDocumentoProfe.Text, dtpFechaIngreso.Value);
            this.Curso = new Curso(anio, division, profesor);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            rtbDatos.Text = (string)this.Curso;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(this.curso, null))
            {
                MessageBox.Show("Debe crear un Curso");
                return;
            }
            Divisiones division;
            Enum.TryParse<Divisiones>(cmbDivisionCurso.SelectedValue.ToString(), out division);
            short anio = (short)nudAnio.Value;
            Alumno alumno = new Alumno(txtNombre.Text, txtApellido.Text, txtLegajo.Text, anio, division);
            this.curso += alumno;
        }

        private void frmVista_Load(object sender, EventArgs e)
        {
            cmbDivision.DataSource = Enum.GetValues(typeof(Divisiones));
            cmbDivisionCurso.DataSource = Enum.GetValues(typeof(Divisiones));
        }
    }
}
