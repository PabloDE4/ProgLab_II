using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio64
{
    class Program
    {
        static void Main(string[] args)
        {
            Caja c1 = new Caja();
            Caja c2 = new Caja();
            Negocio n = new Negocio(c1, c2);
            n.Clientes.Add("Jose Gonzalez");
            n.Clientes.Add("Pedro Diaz");
            n.Clientes.Add("Juan Perez");
            n.Clientes.Add("Daniel Lopez");
            n.Clientes.Add("Daniel Gonzalez");
            n.Clientes.Add("Juan Diaz");
            n.Clientes.Add("Pedro Perez");
            n.Clientes.Add("Jose Lopez");

            Thread HiloAsignarCaja = new Thread(n.AsignarCaja);

            Thread t1 = new Thread(c1.AtenderClientes);
            t1.Name = "Caja 1: ";

            Thread t2 = new Thread(c2.AtenderClientes);
            t2.Name = "Caja 2: ";

            HiloAsignarCaja.Start();
            HiloAsignarCaja.Join();

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine("\nTodos los clientes atendidos");
            Console.ReadKey();
        }
    }
}
