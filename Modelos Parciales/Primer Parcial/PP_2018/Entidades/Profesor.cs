using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Profesor:Persona
    {
        #region Atributos
        private DateTime fechaIngreso;
        #endregion

        #region Propiedades
        /// <summary>
        /// Devolverá la cantidad de tiempo, en días, desde la fecha de ingreso del profesor hasta la actualidad.
        /// </summary>
        public int Antiguedad
        {
            get { return (int)((DateTime.Now - this.fechaIngreso).TotalDays); }
        }
        #endregion

        #region Metodos
        public Profesor(string nombre, string apellido, string documento)
            : base(nombre, apellido, documento)
        { }

        public Profesor(string nombre, string apellido, string documento, DateTime fechaingreso)
            : this(nombre, apellido, documento)
        {
            this.fechaIngreso = fechaingreso;
        }

        /// <summary>
        /// Dará como válido sólo documentos que tengan el formato XX-XXXXX-X. Caso contrario retornará false y no se asignará el documento.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        protected override bool ValidarDocumentacion(string doc)
        {
            bool retorno = false;
            if (doc.Length == 9)
            {
                retorno = true;
            }
            return retorno;
        }

        public override string ExponerDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.ExponerDatos());
            cadena.AppendLine("Antiguedad: " + this.Antiguedad);

            return cadena.ToString();
        }
        #endregion
    }
}
