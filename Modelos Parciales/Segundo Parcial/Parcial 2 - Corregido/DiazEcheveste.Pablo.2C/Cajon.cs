using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace DiazEcheveste.Pablo._2C
{

    public class Cajon<T>:ISerializable
    {

        private int _capacidad;
        private float _precioUnitario;
        private List<T> _frutas;

        /// <summary>
        /// Expone al atributo de tipo List<T>
        /// </summary>
        public List<T> Frutas
        {
            get { return this._frutas; }
        }

        /// <summary>
        /// Retona el precio total del cajon
        /// </summary>
        public float PrecioTotal
        {
            get { return (this._frutas.Count * this._precioUnitario);}
        }        

        public Cajon()
        {
            this._frutas = new List<T>();
        }

        public Cajon(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(int capacidad, float precio) : this(capacidad)
        {
            this._precioUnitario = precio;
        }

        /// <summary>
        /// Agrega frutas al cajon.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Cajon<T> operator +(Cajon<T> c, T f)
        {
            if (c._frutas.Count < c._capacidad)
            {
                c._frutas.Add(f);
            }
            else
            {
                throw new CajonLlenoException();
            }
            return c;

        }

        /// <summary>
        /// Retorna en formato string los atributos del cajon y el listado de todas las frutas en el cajon.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Capacidad: " + this._capacidad);
            sb.AppendLine("Precio unitario: " + this._precioUnitario);

            sb.AppendLine("\n\nListado de Frutas: \n");
            foreach (T item in this._frutas)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        
        public string RutaArchivo
        {
            get;
            set;
        }

        public bool SerializarXml()
        {
            bool retorno = false;

            try
            {
                using (StreamWriter archivo = new StreamWriter(this.RutaArchivo))
                {
                    XmlSerializer s = new XmlSerializer(typeof(Cajon<T>));
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

        public bool DeSerializarXml()
        {
            bool retorno = false;
            Cajon<T> c;
            try
                {
                    using (StreamReader archivo = new StreamReader(this.RutaArchivo))
                    {
                        XmlSerializer s = new XmlSerializer(typeof(Manzana));
                        c = (Cajon<T>)s.Deserialize(archivo);
                        archivo.Close();
                    }

                    this._capacidad = c._capacidad;
                    this._precioUnitario = c._precioUnitario;

                    foreach (T item in c._frutas)
                    {
                        this._frutas.Add(item);
                    }

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
