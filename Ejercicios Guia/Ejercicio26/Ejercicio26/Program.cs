using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio26
{
    class Program
    {
        static void Main(string[] args)
        {
            Random numeros = new Random();
            int[] array = new int[20];
            bool flagSwap;
            int aux;

            //a. Mostrar el vector tal como fue ingresado
            Console.WriteLine("Mostrar array");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = numeros.Next(-100,100);
                Console.WriteLine(array[i]);
            }
            Console.Write("\n");

            //b. Luego mostrar los positivos ordenados en forma decreciente.
            do
            {
                flagSwap = false;
                for (int i = 0; i < (array.Length - 1); i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        flagSwap = true;
                        aux = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = aux;
                    }
                }
            } while (flagSwap);

            Console.WriteLine("Positivos ordenados");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                    Console.WriteLine(array[i]);
            }
            Console.Write("\n");

            //c. Por último, mostrar los negativos ordenados en forma creciente.
            do
            {
                flagSwap = false;
                for (int i = 0; i < (array.Length - 1); i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        flagSwap = true;
                        aux = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = aux;
                    }
                }
            } while (flagSwap);

            Console.WriteLine("Negativos ordenados");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                    Console.WriteLine(array[i]);
            }
            Console.Write("\n");

            Console.ReadKey();
        }
    }
}
