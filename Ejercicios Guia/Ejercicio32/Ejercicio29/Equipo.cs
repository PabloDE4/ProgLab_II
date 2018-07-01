using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio29
{
    public class Equipo
    {
        private short _cantidadDeJugadores;
        private List<Jugador> jugadores;
        private string _nombre;

        private Equipo()
        {
            this.jugadores = new List<Jugador>();
        }

        public Equipo(short cantidad, string nombre)
            : this()
        {
            this._cantidadDeJugadores = cantidad;
            this._nombre = nombre;
        }

        public static bool operator +(Equipo e, Jugador j)
        {
            bool retorno = false;

            //Jugadores no exista en el equipo y la cantidad de jugadores no supere el límite establecido por _cantidadDeJugadores.
            if (!(e.jugadores.Contains(j)) && e.jugadores.Count < e._cantidadDeJugadores)
            {
                e.jugadores.Add(j);
                retorno = true;
            }

            return retorno;
        }

        public string MostrarEquipo()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Equipo: " + this._nombre);
            cadena.AppendLine("\n");

            foreach (Jugador jugador in this.jugadores)
            {
                cadena.Append(jugador.MostrarDatos());
            }

            return cadena.ToString();
        }


    }
}
