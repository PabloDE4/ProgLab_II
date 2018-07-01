using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.Punto6F
{
    public class AlumnoEgresado:Alumno, ISerializar,IDeserializar
    {
        public float _promedio;
        public short _promocion;

        public AlumnoEgresado() : base()
        { }

        public AlumnoEgresado(Alumno a, float prom, short promo) : base(((Persona)a), a._legajo, a._nivel)
        {
            this._promedio = prom;
            this._promocion = promo;
        }


        public bool Xml(string path)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter archivo = new StreamWriter(path))
                {
                    XmlSerializer s = new XmlSerializer(typeof(AlumnoEgresado));
                    s.Serialize(archivo, this);
                    archivo.Close();
                }

                retorno = true;
            }
            catch (Exception e)
            {

                throw e;
            }

            return retorno;
        }

        public bool Xml(string path, out AlumnoEgresado a)
        {
            bool retorno = false;

            try
            {
                using (StreamReader archivo = new StreamReader(path))
                {
                    XmlSerializer s = new XmlSerializer(typeof(AlumnoEgresado));
                    a = (AlumnoEgresado)s.Deserialize(archivo);
                    archivo.Close();
                }

                this._promedio = a._promedio;
                this._promocion = a._promocion;

                retorno = true;
            }
            catch (Exception e)
            {

                throw e;
            }

            return retorno;
        }
    }
}
