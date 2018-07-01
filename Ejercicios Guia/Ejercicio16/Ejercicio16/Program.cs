using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio16
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alum1 = new Alumno("Juan", "Perez", 1234);
            Alumno alum2 = new Alumno("Jose", "Gonzalez", 5678);
            Alumno alum3 = new Alumno("Pedro", "Diaz", 91011);

            alum1.Estudiar(4,8);
            alum2.Estudiar(6, 2);
            alum3.Estudiar(10, 5);

            alum1.CalcularFinal();
            alum2.CalcularFinal();
            alum3.CalcularFinal();

            Console.WriteLine(alum1.Mostrar());
            Console.WriteLine(alum2.Mostrar());
            Console.WriteLine(alum3.Mostrar());

            Console.ReadKey();

        }
    }
}
