using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace Entidades.Punto9F
{
    public class Persona
    {
        public string _nombre;
        public string _apellido;
        public sbyte _edad;

        public Persona()
        { 
        }

        public Persona(string nombre, string apellido, sbyte edad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._edad = edad; 
        }


        public string MostrarBD()
        {
            StringBuilder texto = new StringBuilder();
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.StringBaseDatos);

                SqlCommand comando = new SqlCommand("Select * FROM Personas", conexion);

                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();

                texto.AppendLine("\n\nLISTADO EN BASE DE DATOS\n\n");
                while (reader.Read())
                {
                    texto.AppendFormat("ID: {0}\nApellido: {1}\nNombre: {2}\n Edad: {3}\n", reader[0], reader[2], reader[1], reader[3]);
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
