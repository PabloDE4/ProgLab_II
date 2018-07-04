using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Excepciones;

namespace Entidades
{
    public class Dao : IArchivos<Votacion>
    {
        public static SqlConnection cadenaConexion;
        public static SqlCommand cadenaComando;
        public static SqlDataReader cadenaDataReader;
        

        public Votacion Leer(string nombre)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(string nombre, Votacion objeto)
        {
            bool retorno = false;
            try
            {
                cadenaConexion = new SqlConnection(Properties.Settings.Default.conexion);
                cadenaConexion.Open();
                cadenaComando = new SqlCommand("INSERT INTO " + nombre + " (nombreLey, afirmativos, negativos, abstenciones, nombreAlumno) VALUES ('" + objeto.NombreLey + "','" + objeto.Afirmativo + "','" + objeto.Negativo + "','" + objeto.Abstencion + "','" + "PabloDE" + "')", cadenaConexion);
                cadenaComando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ErrorArchivoException("Error al guardar en la base de datos", e);
            }
            finally
            {
                if (retorno)
                Dao.cadenaConexion.Close();
            }

            return retorno;
        }
    }
}
