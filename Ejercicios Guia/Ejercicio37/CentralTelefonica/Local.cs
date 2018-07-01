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
    public class Local : Llamada, IGuardar<string>
    {
        #region atributos
        protected float _costo;
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
        public Local(Llamada llamada, float costo) :this(llamada.NroOrigen,llamada.Duracion,llamada.NroDestino,costo)
        {
            this.RutaDeArchivo = "Local.xml";
        }

        public Local(string origen, float duracion, string destino, float costo) :base(duracion,destino,origen)
        {
            this._costo = costo;
        }
        #endregion

        #region metodos
        private float CalcularCosto() 
        {
            float costoTotal = this._costo * this.Duracion;
            return costoTotal;
        }

        protected override string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            
            cadena.AppendLine(base.Mostrar());
            cadena.AppendLine("Costo: " + this.CostoLlamada);

            return cadena.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is Local);
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
                XmlSerializer serializer = new XmlSerializer(typeof(Local));
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
                    if (l is Local)
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
