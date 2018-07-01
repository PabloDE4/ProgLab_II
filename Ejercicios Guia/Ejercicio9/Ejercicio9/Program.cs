using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio9
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Ingrese tamaño: ");

            int tam;
            int i, j, z; 

            if(int.TryParse(Console.ReadLine(), out tam)){

                for (i = tam, z = 1; i > 0; i--, z+=1)
                {
                    for (j = 0; j < z; j++)
                    {
                        Console.Write("*");                        
                    }

                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            Console.ReadKey();
        }
    }
}
