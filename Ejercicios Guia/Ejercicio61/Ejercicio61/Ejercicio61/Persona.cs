using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio61
{
    public class Persona
    {
        private string id;
        private string nombre;
        private string apellido;
        
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public Persona(string nomb, string apellido)
        {
            this.nombre = nomb;
            this.apellido = apellido;
        }

        public Persona(string nomb, string apellido, string id):this(nomb, apellido)            
        {
            this.id = id;
        }
    }
}
