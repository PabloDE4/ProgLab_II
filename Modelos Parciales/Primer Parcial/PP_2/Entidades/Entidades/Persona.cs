using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        private string _apellido;
        private string _nombre;

        public string Apellido
        {
            get { return this._apellido; }
        }

        public string Nombre
        {
            get { return this._nombre; }
        }

        public Persona(string nombre, string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        protected abstract string FichaTecnica();

        protected virtual string NombreCompleto()
        {
            string nombreCompleto = String.Format("{0} {1}", this.Nombre, this.Apellido);
            return nombreCompleto;
        }
        
    }
}
