using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Humano:Animal
    {
        private string _apellido;
        private string _nombre;
        private static int _piernas;

        static Humano()
        {
            _piernas = 2;
        }

        public Humano(int velocidadMaxima)
            : base(Humano._piernas, velocidadMaxima)
        { 
        }

        public Humano(string nombre, string apellido, int velocidadMaxima)
            : this(velocidadMaxima)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public string MostrarHumano()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine("Nombre: " + this._nombre);
            cadena.AppendLine("Apellido: " + this._apellido);

            return cadena.ToString();
        }

        public static bool operator ==(Humano h1, Humano h2)
        {
            bool retorno = false;

            if (h1._nombre == h2._nombre && h1._apellido == h2._apellido)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Humano h1, Humano h2)
        {
            return !(h1 == h2);
        }


    }
}
