using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio31
{
    class Program
    {
        static void Main(string[] args)
        {
            Negocio negocio = new Negocio("Mi negocio");
            Cliente c1 = new Cliente(1, "Juan");
            Cliente c2 = new Cliente(2, "Jose");
            Cliente c3 = new Cliente(3, "Gonzalo");
            Cliente c4 = new Cliente(4, "Diego");

            negocio.Cliente = c1;
            negocio.Cliente = c2;
            negocio.Cliente = c3;
            negocio.Cliente = c4;

            while (~negocio)
                Console.WriteLine("Cliente atendido");

            Console.WriteLine("Sin Clientes");


            Console.ReadKey();
        }
    }
}
