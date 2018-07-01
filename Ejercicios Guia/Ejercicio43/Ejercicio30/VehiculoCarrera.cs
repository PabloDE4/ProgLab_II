using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio30
{
    public class VehiculoCarrera
    {
        private short cantidadCombustible;
        private bool enCompetencia;
        private string escuderia;
        private short numero;
        private short vueltasRestantes;

        public short CantidadCombustible
        {
            get { return this.cantidadCombustible; }
            set { this.cantidadCombustible = value; }
        }

        public bool EnCompetencia
        {
            get { return this.enCompetencia; }
            set { this.enCompetencia = value; }
        }

        public string Escuderia
        {
            get { return this.escuderia; }
            set { this.escuderia = value; }
        }

        public short Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public short VueltasRestantes
        {
            get { return this.vueltasRestantes; }
            set { this.vueltasRestantes = value; }
        }

        public VehiculoCarrera(short numero, string escuderia)
        {
            this.numero = numero;
            this.escuderia = escuderia;
        }

        public static bool operator ==(VehiculoCarrera a1, VehiculoCarrera a2)
        {
            bool retorno = false;
            if (a1.Numero == a2.Numero && a1.Escuderia == a2.Escuderia)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(VehiculoCarrera a1, VehiculoCarrera a2)
        {
            return !(a1 == a2);
        }

        public string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Numero           : " + this.Numero);
            cadena.AppendLine("Escuderia        : " + this.Escuderia);
            cadena.AppendLine("En competencia   : " + this.EnCompetencia);
            cadena.AppendLine("Combustible      : " + this.CantidadCombustible);
            cadena.AppendLine("Vueltas restantes: " + this.VueltasRestantes);

            return cadena.ToString();
        }
    }
}
