using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization; 

namespace DiazEcheveste.Pablo._2C
{
    public class Manzana : Fruta, ISerializable
    {

        public string _distribuidora;


        /// <summary>
        /// Retorna true
        /// </summary>
        public override bool TieneCarozo
        {
            get { return true; }
        }

        /// <summary>
        /// Retorna manzana
        /// </summary>
        public string Tipo
        {
            get { return "Manzana"; }
        }



        public Manzana() : base()
        {
        }

        public Manzana(ConsoleColor color, float peso, string distribuidora)
            : base(color, peso)
        {
            this._distribuidora = distribuidora;
        }

        /// <summary>
        /// Se reutiliza y se agrega campos propios.
        /// </summary>
        /// <returns></returns>
        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Tipo: " + this.Tipo);
            sb.Append(base.FrutaToString());
            sb.AppendLine("Tiene carozo?: " + this.TieneCarozo.ToString());
            sb.AppendLine("Distruibora: " + this._distribuidora);

            return sb.ToString();
        }

        /// <summary>
        /// Retorna la representacion de la clase en formato string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.FrutaToString();
        }


        ///////////////////////////////////////SERIALIZACION///////////////////////////////////////////////////////


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
                    XmlSerializer s = new XmlSerializer(typeof(Manzana));
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
            Manzana m;
            try
            {
                using (StreamReader archivo = new StreamReader(this.RutaArchivo))
                {
                    XmlSerializer s = new XmlSerializer(typeof(Manzana));
                    m = (Manzana)s.Deserialize(archivo);
                    archivo.Close();
                }

                this._color = m._color;
                this._distribuidora = m._distribuidora;
                this._peso = m._peso;

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
