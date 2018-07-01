using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inicio
{
    public class Humano
    {
        public string _nombre;

        public ERaza _raza;

        public Humano()
        {
        }

        public Humano(string nombre, ERaza raza)
        {
            this._nombre = nombre;
            this._raza = raza;
        }

        public enum ERaza
        {
            Aria, Mestiza, Negra, Cabeza
        };

        public enum ENivelDeEstudio
        {
            Primaria, Secundaria, Terciaria, Universitaria
        };

    }
}
