using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Novela:Libro
    {
        public EGenero genero;

        public Novela(string titulo, float precio, Autor autor, EGenero genero)
            : base(titulo, autor, precio)
        {
            this.genero = genero;
        }

        private string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Titulo: " + base._titulo);
            cadena.AppendLine("Autor: " + base._autor);
            cadena.AppendLine("Cantidad de paginas: " + base._cantidadDePaginas);
            cadena.AppendLine("Precio: " + base._precio);
            cadena.AppendLine("Genero: " + this.genero);

            return cadena.ToString();
        }

        public static bool operator ==(Novela a, Novela b)
        {
            bool retorno = false;

            if (a.genero == b.genero)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }

        public static implicit operator double(Novela n)
        {
            return n._precio;
        }
    }
}
