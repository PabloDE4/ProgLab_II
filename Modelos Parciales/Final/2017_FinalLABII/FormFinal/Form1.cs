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

namespace FormFinal
{
    public partial class frmFinal : Form
    {
        private MEspecialista medicoEspecialista;
        private MGeneral medicoGeneral;
        private Thread mocker;
        private Queue<Paciente> pacientesEnEspera;

        public frmFinal()
        {
            InitializeComponent();

            this.medicoGeneral = new MGeneral("Luis", "Salinas");
            this.medicoEspecialista = new MEspecialista("Jorge", "Iglesias", MEspecialista.Especialidad.Traumatologo);
            pacientesEnEspera = new Queue<Paciente>();
        }

        private void frmFinal_Load(object sender, EventArgs e)
        {
            mocker = new Thread(MockerPacientes);
            mocker.Start();
        }

        private void frmFinal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mocker.IsAlive)
            {
                mocker.Abort();
            }
        }

        private void MockerPacientes()
        {
            this.pacientesEnEspera.Enqueue(new Paciente("Juan", "Perez"));
            this.pacientesEnEspera.Enqueue(new Paciente("Luis", "Gonzalez"));
            this.pacientesEnEspera.Enqueue(new Paciente("Pedro", "Rodriguez"));
            Thread.Sleep(5000);
        }

        private void AtenderPacientes(IMedico IMedico)
        {
            if (this.pacientesEnEspera.Count > 0 && IMedico is MEspecialista)
            {
                Paciente p = pacientesEnEspera.Dequeue();
                ((MEspecialista)IMedico).IniciarAtencion(p);
                FinAtencion(p, (MEspecialista)IMedico);
            }
            if (this.pacientesEnEspera.Count > 0 && IMedico is MGeneral)
            {
                Paciente p = pacientesEnEspera.Dequeue();
                ((MGeneral)IMedico).IniciarAtencion(p);
                FinAtencion(p, (MGeneral)IMedico);
            }
        }

        public void FinAtencion(Paciente p, Medico m)
        {
            MessageBox.Show(string.Format("Finalizó la atención de {0} por {1}!", p.ToString(), m.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AtenderPacientes(medicoGeneral);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AtenderPacientes(medicoEspecialista);
        }
        
    }
}
