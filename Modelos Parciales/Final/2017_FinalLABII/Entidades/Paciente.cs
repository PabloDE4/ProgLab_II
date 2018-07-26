using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente:Persona
    {
        private int turno;
        static int ultimoTurnoDado;

        public int Turno
        {
            get { return this.turno; }
        }

        static Paciente()
        {
            Paciente.ultimoTurnoDado = 0;
        }

        public Paciente(string nombre, string apellido):base(nombre, apellido)
        {
            this.turno = ultimoTurnoDado++;
        }

        public Paciente(string nombre, string apellido, int turno)
            : this(nombre, apellido)
        {
            Paciente.ultimoTurnoDado = turno;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Turno Nº {0}: {2}, {1}", this.Turno, this.apellido, this.nombre);
            return sb.ToString();
        }
        
    }
}
