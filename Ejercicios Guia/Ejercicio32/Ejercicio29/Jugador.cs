using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio29
{
    public class Jugador
    {
        private long _dni;
        private string _nombre;
        private int _partidosJugados;
        private int _totalGoles;

        private Jugador()
        {
            this._dni = 0;
            this._nombre = "";
            this._partidosJugados = 0;
            this._totalGoles = 0;
        }

        public Jugador(string nombre) : this() 
        {
            this._nombre = nombre;
        }

        public Jugador(string nombre, int totalGoles, int totalPartidos) : this(nombre) 
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
        

        public string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("DNI: " + this._dni);
            cadena.AppendLine("Nombre: " + this._nombre);
            cadena.AppendLine("Goles: " + this._totalGoles);
            cadena.AppendLine("Partidos: " + this._partidosJugados);
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
