using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private string nombre;
        private string documento;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return this.nombre; }
        }

        public string Apellido
        {
            get { return this.apellido; }
        }

        public string Documento
        {
            get { return this.documento; }
            set
            {
                if (ValidarDocumentacion(value))
                {
                    documento = value;
                }
            }                
        }
        #endregion

        #region Metodos
        public Persona(string nombre, string apellido, string documento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
        }

        public virtual string ExponerDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Nombre   : " + Nombre);
            cadena.AppendLine("Apellido : " + Apellido);
            cadena.AppendLine("DNI      : " + Documento);

            return cadena.ToString();
        }

        protected abstract bool ValidarDocumentacion(string doc);
        #endregion
    }
}
