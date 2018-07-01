using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19
{
    class Program
    {
        static void Main(string[] args)
        {
            Sumador sum = new Sumador(2);
            Sumador sum2 = new Sumador();

            Console.WriteLine(sum.Sumar(2, 4));
            Console.WriteLine(sum.Sumar("Hola ", "chau"));

            

            Console.ReadKey();


        }
    }
}
