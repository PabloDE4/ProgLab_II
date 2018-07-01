using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inicio
{
    public class Persona:Humano
    {
        public string _apellido;
        public sbyte _edad;

        public Persona() : base()
        { 
        }

        public Persona(string nombre, string apellido, ERaza raza, sbyte edad) : base(nombre, raza)
        {
            this._apellido = apellido;
            this._edad = edad; 
        }

    }
}
