using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public class Paciente:Persona
    {
      private int turno;
      private static int ultimoTurnoDado;

        public Paciente() 
        { 
        }

        public Paciente(string nombre, string apellido) : base(nombre, apellido)
        {
            Paciente.ultimoTurnoDado++;
            this.turno = Paciente.ultimoTurnoDado;
        }

        public Paciente(string nombre, string apellido, int turno) : this(nombre, apellido)
        {
            this.turno = turno;
            Paciente.ultimoTurnoDado = turno;
        }

        static Paciente()
        {
            Paciente.ultimoTurnoDado = 0;
        }

        public int Turno
        {
            get { return this.turno; }
        }

        public int UltimoTurnoDado
        {
            get { return this.UltimoTurnoDado; }
        }


        public override string ToString()
        {
            return "Turno Nº: {0}: {2}, {1}" + this.Turno + ": " + this.nombre + ", " + this.apellido;
        }

    }
}
