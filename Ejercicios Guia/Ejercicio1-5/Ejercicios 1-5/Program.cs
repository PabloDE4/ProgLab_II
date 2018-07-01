using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola mundo!");

            List<string> nombre = new List<string>();

            nombre.Add("Pablo");
            nombre.Add("Carlos");
            nombre.Add("Juan");

            for (int i = 0; i < nombre.Count; i++)
            {
                string auxNombre = nombre[i];
                nombre.Remove(nombre[0]);
                Console.WriteLine(auxNombre);
            }


            foreach (string auxNombre in nombre)
            {
                Console.WriteLine(auxNombre);
            }

            Console.ReadKey();
        }
    }
}
