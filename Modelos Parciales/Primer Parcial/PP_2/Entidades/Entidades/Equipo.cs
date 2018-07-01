using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        public enum Deportes { Basquet, Futbol, Handball, Rugby }

        private static Deportes deporte;
        private DirectorTecnico dt;
        private List<Jugador> jugadores;
        private string nombre;


        public static Deportes Deporte
        {
            set { deporte = value; }
        }

        static Equipo()
        {
            Equipo.Deporte = Deportes.Futbol;
        }

        private Equipo()
        {
            jugadores = new List<Jugador>();
        }

        public Equipo(string nombre, DirectorTecnico tecnico):this()
        {
            this.nombre = nombre;
            this.dt = tecnico;
        }

        public Equipo(string nombre, DirectorTecnico tecnico, Deportes deporte)
            : this(nombre, tecnico)
        {
            Equipo.deporte = deporte;
        }

        public static bool operator ==(Equipo e, Jugador j)
        {
            bool retorno = false;
            foreach (Jugador jugador in e.jugadores)
            {
                if (jugador == j)
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e==j);
        }

        public static Equipo operator +(Equipo e, Jugador j)
        {
            if (e!=j)
            {
                e.jugadores.Add(j);
            }

            return e;
        }

        public static Equipo operator -(Equipo e, Jugador j)
        {
            if (e == j)
            {
                e.jugadores.Remove(j);
            }

            return e;
        }

        public static implicit operator string(Equipo e)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("\n***** {0} *****\n", e.nombre);
            cadena.AppendLine("\nNómina Jugadores:\n");
            foreach (Jugador j in e.jugadores)
            {
                cadena.AppendLine(j.ToString());
            }
            cadena.AppendFormat("\nDirigido por: {0}", e.dt.ToString());

            return cadena.ToString();  
        }


    }
}
