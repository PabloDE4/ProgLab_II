using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio29;

namespace Ejercicio35
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipo e1 = new Equipo(3, "NUTD");

            Jugador j1 = new Jugador("Matias", 12, 15);
            j1.DNI = 32514869;

            Jugador j2 = new Jugador("Pablo", 2, 16);
            j2.DNI = 37762514;

            Jugador j3 = new Jugador("Lucas", 8, 13);
            j3.DNI = 35963521;

            Jugador j4 = new Jugador("Hernan", 0, 3);
            j4.DNI = 25698742;

            DateTime fechaNac = new DateTime(1949, 06, 28);

            DirectorTecnico dt = new DirectorTecnico("Enrique", fechaNac);
            dt.DNI = 20369879;

            if (e1 + j1 && e1 + j2 && e1 + j3)
            {
                Console.WriteLine(e1.MostrarEquipo());
                Console.WriteLine(dt.MostrarDatosTecnico());
            }
            else
            {
                Console.WriteLine("No se pudo cargar.");
            }

            Console.ReadKey();
        }
    }
}
