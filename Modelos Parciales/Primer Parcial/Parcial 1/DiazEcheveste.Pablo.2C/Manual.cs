using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public class Manual : Libro
    {
        public ETipo tipo;

        

        public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo) : base(new Autor(nombre, apellido), precio, titulo)
        {
            this.tipo = tipo;
        }

        public string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(this.Mostrar());
            cadena.AppendLine("Tipo: " + this.tipo);

            return cadena.ToString();
        }

        public static bool operator ==(Manual a, Manual b)
        {
            bool retorno = false;
            if ((a.GetType() == b.GetType()) && (a.tipo == b.tipo))
                retorno = true;
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
