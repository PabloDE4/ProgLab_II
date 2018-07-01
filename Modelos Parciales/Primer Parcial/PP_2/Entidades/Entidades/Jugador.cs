using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador:Persona
    {
        private bool esCapitan;
        private int numero;

        public bool EsCapitan
        {
            get { return this.esCapitan; }
            set { this.esCapitan = value; }
        }
        
        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }        

        public Jugador(string nombre, string apellido)
            : base(nombre, apellido)
        {
            this.esCapitan = false;
            this.numero = 0;
        }

        public Jugador(string nombre, string apellido, int numero, bool capitan)
            : this(nombre, apellido)
        {
            this.numero = numero;
            this.esCapitan = capitan;
        }
        
        protected override string FichaTecnica()
        {
            string informacion = String.Format("{0} camiseta numero: {1}", this.NombreCompleto(), this.Numero);
            if (this.esCapitan)
            {
                informacion = String.Format("{0}, capitan del equipo, camiseta numero: {1}", this.NombreCompleto(), this.Numero);
            }

            return informacion;
        }

        public static bool operator ==(Jugador j1, Jugador j2)
        {
            bool retorno = false;

            if (j1.Nombre == j2.Nombre && j1.Apellido == j2.Apellido && j1.Numero == j2.Numero)
            {
                retorno = true;
            }

            return retorno; 
        }

        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }

        public static explicit operator int(Jugador jugador)
        {
            return jugador.Numero;
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }

        public override bool Equals(Object obj)
        {
            bool retorno = false;

            if (obj is Jugador)
            {
                retorno = (this==(Jugador)obj);                
            }

            return retorno;
        }

    }
}
