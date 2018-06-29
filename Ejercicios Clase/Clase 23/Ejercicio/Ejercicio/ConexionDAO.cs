using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Ejercicio
{
    public class ConexionDAO
    {
        
        public static SqlConnection cadenaConexion;
        public static SqlCommand cadenaComando;
        public static SqlDataReader cadenaDataReader;


        static ConexionDAO()
        {
            cadenaConexion = new SqlConnection(Properties.Settings.Default.conexion);
        }

        public static bool Guardar(Alumno persona)
        {
            bool retorno = false;
            try
            {
                cadenaConexion.Open();
                cadenaComando = new SqlCommand("INSERT INTO Persona(id, Nombre) VALUES ('" + persona.id + "','" + persona.Nombre + "')", cadenaConexion);
                cadenaComando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cadenaConexion != null)
                {
                    cadenaConexion.Close();
                }
                if (cadenaComando != null)
                {
                    cadenaComando.Dispose();
                }
            }

            return retorno;
        }

        
    }
}
