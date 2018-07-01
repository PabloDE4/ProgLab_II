using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Manual:Libro
    {
        public ETipo tipo;

        public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo)
            : base(titulo, new Autor(nombre,apellido), precio)
        {
            this.tipo = tipo;
        }

        private string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Titulo: " + base._titulo);
            cadena.AppendLine("Autor: " + base._autor);
            cadena.AppendLine("Cantidad de paginas: " + base._cantidadDePaginas);
            cadena.AppendLine("Precio: " + base._precio);
            cadena.AppendLine("Tipo: " + this.tipo);

            return cadena.ToString();
        }

        public static bool operator ==(Manual a, Manual b)
        {
            bool retorno = false;

            if (a.tipo == b.tipo)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Manual a, Manual b)
        {
            return !(a == b);
        }

        public static implicit operator double(Manual m)
        {
            return m._precio;
        }
    }
}
