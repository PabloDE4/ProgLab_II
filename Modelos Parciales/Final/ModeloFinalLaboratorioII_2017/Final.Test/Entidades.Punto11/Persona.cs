using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Punto11
{
    public class Persona
    {
        public string _apellido;
        public sbyte _edad;

        public Persona()
        { 
        }

        public Persona(string nombre, string apellido, sbyte edad) 
        {
            this._apellido = apellido;
            this._edad = edad; 
        }

    }
}
