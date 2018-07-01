using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7
{
    class Program
    {
        static void Main(string[] args)
        {
            int dia = 19;
            int mes = 03;
            int anio = 0;
            int diasVividos = 0;
            DateTime fechaActual = DateTime.Now;

            Console.Write("Ingrese año: ");
            if (int.TryParse(Console.ReadLine(), out anio))
            {
                for (int i = anio; i < fechaActual.Year; i++)
                {
                    if (i % 4 == 0 && (!(i % 100 == 0) || i % 400 == 0))
                    {
                        diasVividos = diasVividos + 366;
                    }
                    else
                    {
                        diasVividos = diasVividos + 365;
                    }
                }

                for (int i = mes; i < fechaActual.Month; i++)
                {
                    if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
                    {
                        diasVividos = diasVividos + 31;
                    }
                    else if (i == 4 || i == 6 || i == 9 || i == 11)
                    {
                        diasVividos = diasVividos + 30;
                    }
                    else if (anio % 4 == 0 && (!(anio % 100 == 0) || anio % 400 == 0))
                    {
                        diasVividos = diasVividos + 29;
                    }
                    else
                    {
                        diasVividos = diasVividos + 28;
                    }
                }

                for (int i = mes; i > fechaActual.Month; i--)
                {
                    if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
                    {
                        diasVividos = diasVividos - 31;
                    }
                    else if (i == 4 || i == 6 || i == 9 || i == 11)
                    {
                        diasVividos = diasVividos - 30;
                    }
                    else if (anio % 4 == 0 && (!(anio % 100 == 0) || anio % 400 == 0))
                    {
                        diasVividos = diasVividos - 29;
                    }
                    else
                    {
                        diasVividos = diasVividos - 28;
                    }
                }

                diasVividos = diasVividos + (fechaActual.Day - dia - 1);

                
                Console.WriteLine("Dias vividos: {0}", diasVividos);

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }
    }
}
