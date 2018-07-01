using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio30
{
    public class MotoCross:VehiculoCarrera
    {
        private short cilindrada;
        
        public short Cilindrada
        {
            get { return this.cilindrada; }
            set { this.cilindrada = value; }
        }

        public MotoCross(short numero, string escuderia)
            : base(numero, escuderia)
        { 
        }

        public MotoCross(short numero, string escuderia, short cilindrada)
            : this(numero, escuderia)
        {
            this.cilindrada = cilindrada;
        }

        public static bool operator ==(MotoCross a, MotoCross b)
        {
            bool retorno = false;

            if (a.Numero == b.Numero && a.Escuderia == b.Escuderia && a.cilindrada == b.cilindrada)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(MotoCross a, MotoCross b)
        {
            return !(a == b);
        }

        public string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine("Cilindrada   : " + this.Cilindrada);

            return cadena.ToString();
        }
    }
}
