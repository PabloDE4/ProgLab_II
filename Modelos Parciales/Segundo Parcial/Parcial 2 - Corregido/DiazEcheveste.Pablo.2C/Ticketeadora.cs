using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace DiazEcheveste.Pablo._2C
{
    public static class Ticketeadora
    {

        public static bool ImprimirTicket(this Cajon<Platano> c, string path)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now + "Precio Total: " + c.PrecioTotal);
                    sw.Close();
                }

                retorno = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return retorno;
            }

            return retorno;
        }


        public static string ObtenerPreciosBD(this ISerializable bd)
        {

            StringBuilder texto = new StringBuilder();
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.StringBaseDatos);

                SqlCommand comando = new SqlCommand("Select * FROM PreciosFruta", conexion);

                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();

                texto.AppendLine("\n\nLISTADO EN BASE DE DATOS\n\n");
                while (reader.Read())
                {
                    texto.AppendFormat("ID: {0}\nDescripcion: {1}\n Precio: {2}\n", reader[0], reader[1], reader[2]);
                    texto.AppendLine("--------------------------------");
                }

                conexion.Close();
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return texto.ToString();
        }
    }
}
