using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Caballo:Animal
    {
        private string _nombre;
        private static int _patas;

        static Caballo()
        {
            _patas = 4;
        }

        public Caballo(string nombre, int velocidadMaxima)
            : base(Caballo._patas, velocidadMaxima)
        {
            this._nombre = nombre;
        }

        public string MostrarCaballo()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine("Nombre: " + this._nombre);

            return cadena.ToString();
        }

        public static bool operator ==(Caballo c1, Caballo c2)
        {
            bool retorno = false;

            if (c1._nombre == c2._nombre)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Caballo c1, Caballo c2)
        {
            return !(c1 == c2);
        }
    }
}
