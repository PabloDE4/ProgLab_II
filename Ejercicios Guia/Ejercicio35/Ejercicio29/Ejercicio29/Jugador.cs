using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio29
{
    public class Jugador:Persona
    {
        private int _partidosJugados;
        private int _totalGoles;

        public Jugador(string nombre, int totalGoles, int totalPartidos) : base(nombre) 
        {
            this._totalGoles = totalGoles;
            this._partidosJugados = totalPartidos;
        }

        public float PromedioGol
        {
            get {
                float promedioGol;

                if (this._partidosJugados != 0)
                {
                    promedioGol = (this._totalGoles / (float)this._partidosJugados);
                }
                else
                {
                    promedioGol = 0;
                }
                return promedioGol; 
            }
        }

        public int PartidosJugados
        {
            get { return this._partidosJugados; }
        }

        public int TotalGoles
        {
            get { return this._totalGoles; }
        }            
                

        public string MostrarDatosJugador()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Jugador: \n");
            cadena.AppendLine(base.MostrarDatosPersona());
            cadena.AppendLine("Goles          : " + this._totalGoles);
            cadena.AppendLine("Partidos       : " + this._partidosJugados);
            cadena.AppendLine("Promedio de gol: " + this.PromedioGol);
            cadena.AppendLine("\n");

            return cadena.ToString();
        }

        public static bool operator ==(Jugador j1, Jugador j2) 
        {
            bool retorno = false;

            if (j1._dni == j2._dni)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Jugador j1, Jugador j2) 
        {
            return !(j1 == j2);
        }
    }
}
