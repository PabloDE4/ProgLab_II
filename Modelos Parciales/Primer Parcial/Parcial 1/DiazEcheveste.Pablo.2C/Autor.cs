using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public class Autor
    {
        private string apellido;
        private string nombre;

        public Autor(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public static bool operator ==(Autor a, Autor b)
        {
            return (a.GetType() == b.GetType()) && (a.nombre == b.nombre) && (a.apellido == b.apellido);
        }

        public static bool operator !=(Autor a, Autor b)
        {
            return !(a == b);
        }

        public static implicit operator string(Autor aut)
        {
            string datos = "Nombre: " + aut.nombre + " " + "Apellido: " + aut.apellido;
            return datos;
        }

    }
}
