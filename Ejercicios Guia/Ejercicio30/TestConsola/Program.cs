﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio30;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Competencia c1 = new Competencia(15, 3, Ejercicio30.TipoCompetencia.Motocross);
            Competencia c2 = new Competencia(25, 16, Ejercicio30.TipoCompetencia.F1);
            AutoF1 a1 = new AutoF1(1, "Mercedes");
            AutoF1 a2 = new AutoF1(2, "Ferrari");
            AutoF1 a3 = new AutoF1(3, "RedBull");
            MotoCross m1 = new MotoCross(4, "FMX");

            if (c1 + m1)
            {
                Console.WriteLine(c1.MostrarDatos());
            }
                        
            if (c2 + a1 && c2 + a2 && c2 + a3)
            {
                Console.WriteLine(c2.MostrarDatos());
            }

            Console.ReadKey();
        }
    }
}
