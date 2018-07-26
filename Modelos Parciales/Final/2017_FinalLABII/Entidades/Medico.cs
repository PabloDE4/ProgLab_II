using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Medico:Persona
    {
        private Paciente pacienteActual;
        protected static Random tiempoAleatorio;

        public delegate void FinAtencionPaciente();
        public event FinAtencionPaciente AtencionFinalizada;

        
        public Paciente AtenderA
        {
            set { this.pacienteActual = value; }
        }

        public virtual string EstaAtendiendoA
        {
            get { return pacienteActual.ToString(); }
        }


        static Medico()
        {
            Medico.tiempoAleatorio = new Random();
        }

        public Medico(string nombre, string apellido):base(nombre, apellido)
        {
 
        }

        public abstract void Atender();

        public void FinalizarAtencion()
        {
            this.AtencionFinalizada();
            this.pacienteActual = null; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Dr. {0}, {1}", this.apellido, this.nombre);
            return sb.ToString();
        }
        
    }
}
