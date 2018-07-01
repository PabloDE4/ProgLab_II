using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public class Novela : Libro
    {
        public EGenero genero;
        
        public Novela(string titulo, float precio, string nombre, string apellido, EGenero genero): base(new Autor(nombre, apellido), precio, titulo)
        {
            this.genero = genero;
        }

        public string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(this.Mostrar());
            cadena.AppendLine("Genero: " + this.genero);

            return cadena.ToString();
        }

        public static bool operator ==(Novela a, Novela b)
        {
            bool retorno = false;
            if ((a.GetType() == b.GetType()) && (a.genero == b.genero))
                retorno = true;
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
