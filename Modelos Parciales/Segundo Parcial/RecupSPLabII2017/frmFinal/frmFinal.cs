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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Entidades;

namespace frmFinal
{
    public partial class frmFinal : Form
    {

        public frmFinal()
        {
            InitializeComponent();
            this.pacientesEnEspera = new Queue<Paciente>();
            this.medicoEspecialista = new MEspecialista("Jorge", "Iglesias", MEspecialista.Especialidad.Traumatologo);
            this.medicoEspecialista.AtencionFinalizada += this.finAtencionPaciente;
            this.medicoGeneral = new MGeneral("Luis", "Salinas");
            this.medicoGeneral.AtencionFinalizada += this.finAtencionPaciente;
        }

        private MEspecialista medicoEspecialista;
        private MGeneral medicoGeneral;
        private Thread mocker;
        private Queue<Paciente> pacientesEnEspera;

        private void AtenderPacientes(IMedico IMedico)
        {
            if (this.pacientesEnEspera.Count > 0 && IMedico is MEspecialista)
            {
                ((MEspecialista)IMedico).iniciarAtencion(this.pacientesEnEspera.Dequeue());
            }
            if (this.pacientesEnEspera.Count > 0 && IMedico is MGeneral)
            {
                ((MGeneral)IMedico).iniciarAtencion(this.pacientesEnEspera.Dequeue());
            }
        }

        private void finAtencionPaciente(Paciente p, Medico m)
        {
            MessageBox.Show(string.Format("Finalizó la atención de {0} por {1}", p.Nombre, m.Nombre));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Medico General
            this.AtenderPacientes(this.medicoGeneral);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Especialista
            this.AtenderPacientes(this.medicoEspecialista);
        }

        private void frmFinal_Load(object sender, EventArgs e)
        {
            this.mocker = new Thread(this.MockPacientes);
            this.mocker.Start();
        }

        private void frmFinal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.mocker.IsAlive) 
            {
                this.mocker.Abort();
            }            
        }

        void MockPacientes()
        {
            this.pacientesEnEspera.Enqueue(new Paciente("Juan","Perez"));
            this.pacientesEnEspera.Enqueue(new Paciente("Luis","Gonzalez"));
            Thread.Sleep(5000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Paciente> Lista = new List<Paciente>(this.pacientesEnEspera);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Paciente>));
            StreamWriter sw = new StreamWriter("Serializado.xml");
            serializer.Serialize(sw, Lista);
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filename = "Serializado.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Paciente>));
            FileStream fstream = new FileStream(filename, FileMode.Open);
            XmlReader reader = XmlReader.Create(fstream);
            List<Paciente> lp = (List<Paciente>)serializer.Deserialize(reader);
            fstream.Close();
            this.pacientesEnEspera = new Queue<Paciente>(lp); 
        }
    }
}
