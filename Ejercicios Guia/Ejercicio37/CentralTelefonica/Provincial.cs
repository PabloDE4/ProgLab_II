using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace CentralTelefonica
{
    public class Provincial : Llamada, IGuardar<string>
    {
        public enum Franja{Franja_1, Franja_2, Franja_3}

        #region atributos
        protected Franja _franjaHoraria;
        protected string rutaDeArchivo;
        #endregion

        #region propiedades


        public override float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        public string RutaDeArchivo
        {
            get { return this.rutaDeArchivo; }
            set { this.rutaDeArchivo = value; }
        }
        #endregion

        #region constructores

        public Provincial(Franja miFranja, Llamada llamada)
            : base(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen)
        {
            this.RutaDeArchivo = "Provincial.xml";
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            : base(duracion, destino, origen)
        {
            this._franjaHoraria = miFranja;
        }

        #endregion

        #region metodos
        private float CalcularCosto()
        {
            float costo = 0;
            float retorno = 0;

            switch (this._franjaHoraria)
            {
                case Franja.Franja_1:
                    costo = (float)0.99;
                    break;
                case Franja.Franja_2:
                    costo = (float)1.25;
                    break;
                case Franja.Franja_3:
                    costo = (float)0.66;
                    break;
            }

            return retorno = costo * this.Duracion;        
        }

        protected override string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.Mostrar());
            cadena.AppendLine("Franja: " + this._franjaHoraria);
            cadena.AppendLine("Costo : " + this.CostoLlamada);

            return cadena.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is Provincial);
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public bool Guardar()
        {
            bool retorno = false;
            XmlTextWriter writer = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Provincial));
                writer = new XmlTextWriter(this.RutaDeArchivo, null);
                serializer.Serialize(writer, this);
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                writer.Close();
            }

            return retorno;
        }

        public string Leer()
        {
            string retorno = "";

            if (File.Exists(this.RutaDeArchivo))
            {
                XmlTextReader reader = null;
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Llamada));
                    reader = new XmlTextReader(this.RutaDeArchivo);
                    Llamada l = (Llamada)serializer.Deserialize(reader);
                    if (l is Provincial)
                    {
                        retorno = l.ToString();
                    }
                    else
                    {
                        throw new InvalidCastException();
                    }
                }
                catch (InvalidCastException e)
                {
                    throw e;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Close();
                }
            }
            return retorno;
        }
        #endregion
    }
}
