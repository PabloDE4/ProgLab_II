using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio29
{
    public class DirectorTecnico:Persona
    {
        protected DateTime _fechaNacimiento;

        public DirectorTecnico(string nombre)
            : base(nombre)
        { 
        }

        public DirectorTecnico(string nombre, DateTime fechaNacimiento)
            : this(nombre)
        {
            this._fechaNacimiento = fechaNacimiento;
        }

        public string MostrarDatosTecnico()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Director Tecnico: \n");
            cadena.AppendLine(base.MostrarDatosPersona());
            cadena.AppendLine("Fecha de nacimiento: " + this._fechaNacimiento);

            return cadena.ToString();
        }

        public static bool operator ==(DirectorTecnico dt1, DirectorTecnico dt2)
        {
            bool retorno = false;

            if (dt1._dni == dt2._dni)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(DirectorTecnico dt1, DirectorTecnico dt2)
        {
            return !(dt1 == dt2);
        }
    }
}
