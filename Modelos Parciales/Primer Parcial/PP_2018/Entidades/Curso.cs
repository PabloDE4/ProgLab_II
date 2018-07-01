using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso
    {
        #region Atributos
        private List<Alumno> alumnos;
        private short anio;
        private Divisiones division;
        private Profesor profesor;
        #endregion

        #region Propiedades
        public string AnioDivision
        {
            get { return this.anio + "º" + this.division; }
        }
        #endregion

        #region Metodos
        private Curso()
        {
            alumnos = new List<Alumno>();
        }

        public Curso(short anio, Divisiones division, Profesor profesor):this()
        {
            this.anio = anio;
            this.division = division;
            this.profesor = profesor;
        }
        #endregion

        #region Sobrecarga
        public static bool operator ==(Curso c, Alumno a)
        {
            bool retorno = false;

            if (a.AnioDivision == c.AnioDivision)
            {                  
               retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Curso c, Alumno a)
        {
            return !(c == a);
        }

        public static Curso operator +(Curso c, Alumno a)
        {
            if (c == a)
            {
                c.alumnos.Add(a);
            }

            return c;
        }

        public static explicit operator string(Curso c)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("\n***** Alumnos *****\n");
            foreach (Alumno alumno in c.alumnos)
            {
                cadena.AppendLine(alumno.ExponerDatos());
            }
            cadena.AppendLine("\n********************\n");
            cadena.AppendLine("\n*Profesor: \n" + c.profesor.ExponerDatos());
            cadena.AppendLine("Año y division: " + c.AnioDivision);

            return cadena.ToString();
        }
        #endregion
    }
}
