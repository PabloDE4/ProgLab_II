using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiazEcheveste.Pablo._2C;

namespace Test
{
    class Program
    {
        private static bool Serializar(ISerializable obj)
        {
            return obj.SerializarXml();
        }

        private static bool DeSerializar(ISerializable obj)
        {
            return obj.DeSerializarXml();
        }

        private static string ObtenerPreciosBD(ISerializable obj)
        {
            return obj.ObtenerPreciosBD();
        }


        static void Main(string[] args)
        {
            Cajon<Manzana> cajonManzana = new Cajon<Manzana>(2, 3.2f);
            Cajon<Platano> cajonPlatano = new Cajon<Platano>(2, 25.1f);

            cajonManzana.RutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "CajonManzanas.xml";
            cajonPlatano.RutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "CajonPlatanos.xml";

            Manzana manzana1 = new Manzana(ConsoleColor.Red, 0.5f, "Frutol");
            Manzana manzana2 = new Manzana(ConsoleColor.Red, 0.6f, "Frutita");
            Manzana manzana3 = new Manzana(ConsoleColor.Red, 0.5f, "Frutalina");

            Platano platano1 = new Platano(ConsoleColor.Yellow, 0.3f, "Ecuador");
            Platano platano2 = new Platano(ConsoleColor.Yellow, 0.3f, "Brasil");
            Platano platano3 = new Platano(ConsoleColor.Green, 0.6f, "Ecuador");


            //Cargo Cajon de manzanas
            cajonManzana += manzana1;
            cajonManzana += manzana2;

            try
            {
                cajonManzana += manzana3;
            }
            catch (CajonLlenoException e)
            {
                Console.WriteLine(e.Message);
            }

            //Cargo Cajon de Platanos
            cajonPlatano += platano1;
            cajonPlatano += platano2;

            try
            {
                cajonPlatano += platano3;
            }
            catch (CajonLlenoException e)
            {
                Console.WriteLine(e.Message);
            }

            //Muestro cajones
            Console.WriteLine(cajonPlatano.ToString());
            Console.WriteLine(cajonManzana.ToString());

            //Imprimo ticket de cajon de Platanos
            if (cajonPlatano.ImprimirTicket(AppDomain.CurrentDomain.BaseDirectory + "CajonDePlatanos.txt"))
                Console.WriteLine("Ticket impreso correctamente");

            //Serializo los dos cajones
            if (Serializar(cajonPlatano))
                Console.WriteLine("Cajon de platanos serializado correctamente.");

            if (Serializar(cajonManzana))
                Console.WriteLine("Cajon de manzana serializado correctamente.");

            //Muestro string de base de datos
            Console.WriteLine(ObtenerPreciosBD(cajonManzana));

            Console.ReadKey();
        }
                
    }
}
