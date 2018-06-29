using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

using System.Data.Sql;
using System.Data.SqlClient;

namespace Ejercicio
{
    public class Alumno
    {
        public int id;
        public string Nombre;
        
        public Alumno()
        {

        }

        public Alumno(int id, string nomb)
            : this()
        {
            this.id = id;
            this.Nombre = nomb;
        }

        public void DeSerializarXml(object ruta)
        {
            try
            {
                XmlTextReader reader;
                XmlSerializer ser;
                Alumno aux = new Alumno();
                reader = new XmlTextReader((string)ruta);
                ser = new XmlSerializer(typeof(Alumno));
                aux = (Alumno)ser.Deserialize(reader);
                reader.Close();

                this.id = aux.id;
                this.Nombre = aux.Nombre;

                ConexionDAO.Guardar(aux);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
