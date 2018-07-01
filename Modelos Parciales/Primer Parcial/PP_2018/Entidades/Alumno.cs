using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Alumno:Persona
    {
        #region Atributos
        private short anio;
        private Divisiones division;
        #endregion

        #region Propiedades
        public string AnioDivision
        {
            get { return this.anio + "º" + this.division; }
        }
        #endregion

        #region Metodos
        public Alumno(string nombre, string apellido, string documento, short anio, Divisiones division)
            : base(nombre, apellido, documento)
        {
            this.anio = anio;
            this.division = division;
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
                for (int i = 0; i < doc.Length; i++)
                {
                    // Valido posición de los guiones
                    if (i == 2 || i == 7)
                    {
                        if (doc[i] != '-')
                            retorno = false;
                    }
                    else
                    {
                        // Valido posición de los números
                        if (!char.IsNumber(doc[i]))
                            retorno = false;
                    }

                }
                retorno = true;
            }
            return retorno;

        }

        public override string ExponerDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.ExponerDatos());
            cadena.AppendLine("Año y division: \n" + this.AnioDivision);

            return cadena.ToString();
        }
        #endregion
    }
}
