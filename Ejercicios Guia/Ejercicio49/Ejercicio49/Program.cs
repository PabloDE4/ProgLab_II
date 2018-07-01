using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio30;

namespace Ejercicio49
{
    class Program
    {
        static void Main(string[] args)
        {
            Competencia<VehiculoCarrera> c1 = new Competencia<VehiculoCarrera>(15, 3, Ejercicio30.TipoCompetencia.F1);
            Competencia<VehiculoCarrera> c2 = new Competencia<VehiculoCarrera>(15, 3, Ejercicio30.TipoCompetencia.Motocross);

            AutoF1 a1 = new AutoF1(1, "Mercedes");
            AutoF1 a2 = new AutoF1(2, "Ferrari");
            AutoF1 a3 = new AutoF1(3, "RedBull");
            MotoCross m1 = new MotoCross(4, "FMX", 3);

            try
            {
                if (c1 + m1)
                {
                    Console.WriteLine(c1.MostrarDatos());
                }
            }
            catch (CompetenciaNoDisponibleException e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                if (c1 + a1 && c1 + a2 && c1 + a3)
                {
                    Console.WriteLine(c1.MostrarDatos());
                }
            }
            catch (CompetenciaNoDisponibleException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();

        }
    }
}
