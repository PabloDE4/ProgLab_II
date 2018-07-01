using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void finAtencionPaciente(Paciente p, Medico m);

    public abstract class Medico:Persona
    {
        public event finAtencionPaciente AtencionFinalizada;

        protected Paciente pacienteActual;
        protected static Random tiempoAleatorio;

        public Medico(string nombre, string apellido) : base(nombre, apellido)
        {
        }

        static Medico()
        {
            Medico.tiempoAleatorio = new Random();
        }

        public Paciente AtenderA
        {
            set{this.pacienteActual = value;}
        }
        public virtual string EstaAtendiendoA
        {
            get{return this.pacienteActual.ToString();}
        }

        protected abstract void Atender();

        protected void finalizarAtencion()
        {
            this.AtencionFinalizada(this.pacienteActual, this);
            this.pacienteActual = null;
        }
                

    }
}
