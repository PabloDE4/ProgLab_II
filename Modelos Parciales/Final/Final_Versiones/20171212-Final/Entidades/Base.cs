using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public abstract class Base
    {
        private static int subversion;
        private static int version;

        protected static SqlConnection cadenaConexion;
        protected static SqlCommand cadenaComando;
        protected static SqlDataReader cadenaDataReader;

        public string Version
        {
            get { return string.Format("{0}", Base.version); }
            set {
                    int aux;
                    if (int.TryParse(value, out aux))
                    {
                        Base.version = aux;
                    }
                }
        }


        public abstract string VersionFull
        {
            get;
        }

        static Base()
        {
            Base.version = 1;
            Base.subversion = 0;
 
        }

        public Base(int version, int subversion)
        {
            Base.version = version;
            Base.subversion = subversion;
        }

        public virtual string MostrarVersion()
        {
            return string.Format("{0}.{1}", Base.version, Base.subversion);
        }

        public static string operator ~(Base b)
        {
            int punto = b.MostrarVersion().IndexOf('.');
            return string.Format("{0}.{1}", b.MostrarVersion().Substring(punto), b.MostrarVersion().Substring(0, punto));
        }

        public override int GetHashCode()
        {
            return Base.version + Base.subversion;
        }

        public static bool GuardarDatos<T>(T dato) where T : Base
        {
            SqlConnection cadenaConexion = new SqlConnection(Properties.Settings.Default.conexion);
            SqlCommand cadenaComando = new SqlCommand();
            try
            {
                cadenaComando.Connection = cadenaConexion;
                cadenaComando.CommandType = System.Data.CommandType.Text;
                cadenaConexion.Open();
                if (dato is DerivadaUno)
                    cadenaComando.CommandText = string.Format("INSERT INTO Datos VALUES({0},{1},{2},{3}", version, subversion, dato.VersionFull.Substring(dato.VersionFull.LastIndexOf('.')), 1);
                else
                    cadenaComando.CommandText = string.Format("INSERT INTO Datos VALUES({0},{1},{2},{3}", version, subversion, 0, 2);

                cadenaComando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cadenaConexion.Close();
            }

            return true;
        }

        public static Queue<T> LeerDatos<T>() where T : Base, new()
        {
            Queue<T> datos = new Queue<T>();
            Queue<Base> datosBase = new Queue<Base>();

            try
            {
                cadenaConexion.Open();
                cadenaComando = new SqlCommand("SELECT * FROM Datos", cadenaConexion);
                cadenaDataReader = cadenaComando.ExecuteReader();

                while (cadenaDataReader.Read())
                {
                    if (cadenaDataReader["derivada"].ToString() == "1")
                    {

                        datosBase.Enqueue(new DerivadaUno(Convert.ToInt32(cadenaDataReader["version"]), Convert.ToInt32(cadenaDataReader["subversion"]), Convert.ToInt32(cadenaDataReader["revision"])));
                    }
                    else
                    {
                        datosBase.Enqueue(new DerivadaDos());
                    }
                }
                datos = (Queue<T>)Convert.ChangeType(datosBase, typeof(Queue<T>));
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos", ex);
            }

            return datos;
        }

        public delegate void DelegadoBase(List<Base> list);
        public static event DelegadoBase EventoBase;

        public void EjecutarEvento(List<Base> lista)
        {
            foreach (Base b in lista)
            {
                if (b is DerivadaUno)
                    Base.GuardarDatos<DerivadaUno>((DerivadaUno)b);
                else
                    Base.GuardarDatos<DerivadaDos>((DerivadaDos)b);
            }
            EventoBase(lista);
 
        }
    }
}
