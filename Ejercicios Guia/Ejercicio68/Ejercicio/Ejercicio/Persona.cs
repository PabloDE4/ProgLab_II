using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio68
{
    public delegate void DelegadoString(string msg);

    public class Persona
    {
        private string apellido;
        private string nombre;

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public Persona(string apellido, string nombre)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Nombre: " + Nombre + " Apellido: " + Apellido);

            return cadena.ToString();
        }
    }
}
