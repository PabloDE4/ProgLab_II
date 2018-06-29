using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_2
{
    class Program
    {
        /// <summary>
        /// Conversor de Binario ASCII a Entero y biceversa
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// 

        static void Main(string[] args)
        {
            int key;
            int numeroUsuario;
            bool continuar = true;

            Calculador acumulador1 = new Calculador("usuario1");
            Calculador acumulador2 = new Calculador("usuario2");
            Calculador acumulador3 = new Calculador("usuario3");

            do
            {
                // Menú
                Console.WriteLine("1 - Convertir de Binario a Entero");
                Console.WriteLine("2 - Convertir de Entero a Binario");
                Console.WriteLine("3 - Salir\n");
                // Fin Menú

                // Si el valor ingresa por el usuario NO es válido, fuerzo la iteración,
                // salteando el código que está por debajo
                if(!int.TryParse(Console.ReadKey().KeyChar.ToString(), out key))
                    continue;
                Console.WriteLine("");

                // Según la tecla presionada por el usuario...
                switch(key)
                {
                    case 1:
                        Console.WriteLine("Ingrese un valor Binario ASCII a convertir a Entero: \n");

                        //Guardo el valor en una variable para pasarlo al metodo de la clase.
                        string valorBinario = Console.ReadLine();
                        Console.WriteLine("\nEl valor es: " + Conversor.BinarioEntero(valorBinario));
                        Console.WriteLine("");

                        Console.WriteLine("\nIngrese usuario: \n");
                        if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out numeroUsuario))
                        continue;
                        Console.WriteLine("");

                        switch (numeroUsuario)
                        {
                            case 1:
                                acumulador1.acumular(valorBinario);
                                break;
                            case 2:
                                acumulador2.acumular(valorBinario);
                                break;
                            case 3:
                                acumulador3.acumular(valorBinario);
                                break;
	                    }

                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("Ingrese un valor Entero a convertir a Binario ASCII: \n");
                        int converso;
                        if (int.TryParse(Console.ReadLine(), out converso))
                        {
                            Console.WriteLine(Conversor.EnteroBinario(converso));
                        }
                        else { 
                            Console.WriteLine("¡Valor inválido!");
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        continuar = false;
                        break;
                }

                Console.Clear();
            } while(continuar);

            Console.WriteLine("Usuario 1 acumulo: " + acumulador1.getResultadoEntero());
            Console.Write("");

            Console.WriteLine("Usuario 2 acumulo: " + acumulador2.getResultadoEntero());
            Console.Write("");

            Console.WriteLine("Usuario 3 acumulo: " + acumulador3.getResultadoEntero());
            Console.Write("");

            Console.ReadKey();
        }

    }
}
