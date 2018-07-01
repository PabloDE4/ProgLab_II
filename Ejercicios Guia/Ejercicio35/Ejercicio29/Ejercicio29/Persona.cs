using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio29
{
    public class Persona
    {
        protected long _dni;
        protected string _nombre;

        public Persona(string nombre)
        {
            this._nombre = nombre;
        }

        public Persona(long dni, string nombre):this(nombre)
        {
            this._dni = dni;
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public long DNI
        {
            get { return this._dni; }
            set { this._dni = value; }
        }   

        public string MostrarDatosPersona()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("DNI   : " + this._dni);
            cadena.AppendLine("Nombre: " + this._nombre);

            return cadena.ToString();
        }


    }
}
