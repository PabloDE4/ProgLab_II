using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Ejercicio61
{
    public class PersonaDAO
    {
        public static SqlConnection cadenaConexion;
        public static SqlCommand cadenaComando;
        public static SqlDataReader cadenaDataReader;

        static PersonaDAO()
        {
            cadenaConexion = new SqlConnection(Properties.Settings.Default.conexion);
        }

        //Data Source=(LocalDB)\v11.0;AttachDbFilename="E:\ProgLabII_2018\Ejercicios Guia\Ejercicio61\Ejercicio61\Persona.mdf";Integrated Security=True;Connect Timeout=30

        public static bool Guardar(Persona persona)
        {
            bool retorno = false;
            try
            {
                cadenaConexion.Open();
                cadenaComando = new SqlCommand("INSERT INTO Persona(Nombre,Apellido) VALUES ('" + persona.Nombre + "','" + persona.Apellido + "')", cadenaConexion);
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

        public static List<Persona> Leer()
        {
            List<Persona> lista = new List<Persona>();
            try
            {
                cadenaConexion.Open();
                cadenaComando = new SqlCommand("SELECT Nombre, Apellido, ID FROM Persona", cadenaConexion);
                cadenaDataReader = cadenaComando.ExecuteReader();
                while (cadenaDataReader.Read())
                {
                    Persona p = new Persona(cadenaDataReader["Nombre"].ToString(), cadenaDataReader["Apellido"].ToString(), cadenaDataReader["ID"].ToString());
                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cadenaConexion.State == ConnectionState.Open)
                {
                    cadenaConexion.Close();
                }
            }

            return lista;
        }

        public static Persona LeerPorID(string ID)
        {
            Persona persona = null;
            try
            {
                cadenaConexion.Open();
                cadenaComando = new SqlCommand("SELECT (Nombre, Apellido) FROM Persona WHERE ID = " + ID, cadenaConexion);
                cadenaDataReader = cadenaComando.ExecuteReader();
                if (cadenaDataReader.Read())
                {
                    persona = new Persona(cadenaDataReader["Nombre"].ToString(), cadenaDataReader["Apellido"].ToString(), cadenaDataReader["ID"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cadenaConexion.State == ConnectionState.Open)
                {
                    cadenaConexion.Close();
                }
            }

            return persona;
        }

        public static bool Modificar(string ID, string nombre, string apellido)
        {
            bool retorno = false;
            try
            {
                cadenaConexion.Open();
                cadenaComando = new SqlCommand("UPDATE Persona SET Nombre = '" + nombre + "',Apellido = '" + apellido + "' WHERE ID = " + ID, cadenaConexion);
                cadenaComando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cadenaConexion.State == ConnectionState.Open)
                {
                    cadenaConexion.Close();
                }
            }

            return retorno;
        }

        public static bool Borrar(string ID)
        {
            bool retorno = false;
            try
            {
                cadenaConexion.Open();
                cadenaComando = new SqlCommand("DELETE FROM Persona WHERE ID = " + ID, cadenaConexion);
                cadenaComando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cadenaConexion.State == ConnectionState.Open)
                {
                    cadenaConexion.Close();
                }
            }
            return retorno;
        }


    }
}
