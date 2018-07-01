using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorTecnico dt = new DirectorTecnico("Jorge", "Habbeger");
            Equipo e1 = new Equipo("Huracán de San Rafael Futbol", dt, Equipo.Deportes.Futbol);
            Jugador j1 = new Jugador("Fernando", "Pandolfi", 11, true);
            Jugador j2 = new Jugador("Julio", "Marchant", 8, false);
            Jugador j3 = new Jugador("Julio", "Marchant", 8, false);
            Jugador j4 = new Jugador("Ezequiel", "Medran", 12, false);
            Jugador j5 = new Jugador("Ezequiel", "Medran", 12, false);
            Jugador j6 = new Jugador("Pedro", "Monchot", 2, true);
            e1 = e1 + j1; //Agrego a jugador 1
            e1 += j2; //Agrego jugador 2
            e1 -= j3; //Borro a jugador 2 usando a jugador 3 que tiene los mismos datos. 
            e1 += j4; //Agrego jugador 4
            e1 += j5; //Trato de agregar a jugador 5 que tiene los mismos datos que jugador 4.

            DirectorTecnico dt2 = new DirectorTecnico("Zurdo", "Lopez");
            Equipo e2 = new Equipo("San Rafael FC", dt2);
            e2 += j6;//Agrego jugador 6

            Console.WriteLine((string)e1);
            Console.WriteLine((string)e2);
            Console.ReadKey();

        }
    }
}
