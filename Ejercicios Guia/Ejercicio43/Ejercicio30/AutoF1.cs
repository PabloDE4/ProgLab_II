using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio30
{
    public class AutoF1:VehiculoCarrera
    {
        private short caballosDeFuerza;
        
        public short CaballosDeFuerza
        {
            get { return this.caballosDeFuerza; }
            set { this.caballosDeFuerza = value; }
        }


        public AutoF1(short numero, string escuderia)
            : base(numero, escuderia)
        {
            base.EnCompetencia = false;
            base.CantidadCombustible = 0;
            base.VueltasRestantes = 0;
        }

        public AutoF1(short numero, string escuderia, short caballos)
            : this(numero, escuderia)
        {
            this.caballosDeFuerza = caballos;
        }


        public static bool operator ==(AutoF1 a, AutoF1 b)
        {
            bool retorno = false;

            if (a.Numero == b.Numero && a.Escuderia == b.Escuderia && a.CaballosDeFuerza == b.CaballosDeFuerza)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(AutoF1 a, AutoF1 b)
        {
            return !(a == b);
        }

        public string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine("Caballos de fuerza   : " + this.caballosDeFuerza);

            return cadena.ToString();
        }
    }
}
