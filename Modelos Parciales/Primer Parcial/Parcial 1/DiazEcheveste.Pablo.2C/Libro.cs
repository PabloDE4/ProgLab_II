using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public class Libro
    {
        protected Autor _autor;
        protected int _cantidadDePaginas;
        protected static Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;

        static Libro()
        {
            _generadorDePaginas = new Random();
        }

        public Libro(Autor autor, float precio, string titulo)
        {
            this._autor = autor;
            this._precio = precio;
            this._titulo = titulo;
        }

        public Libro(string nombre, string apellido, float precio, string titulo): this(new Autor(nombre, apellido), precio, titulo)
        {

        }

        public int CantidadDePaginas
        {
            get
            {
                if (_cantidadDePaginas == 0)
                    this._cantidadDePaginas = _generadorDePaginas.Next(10, 580);

                return this._cantidadDePaginas; 
            }
        }

        private string Mostrar(Libro l)
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Titulo: " + l._titulo);
            cadena.AppendLine("Autor: " + l._autor);
            cadena.AppendLine("Cantidad de paginas: " + l._cantidadDePaginas);
            cadena.AppendLine("Precio: " + l._precio);

            return cadena.ToString();
        }

        public static bool operator ==(Libro a, Libro b)
        {
            bool retorno = false;
            if ((a._titulo == b._titulo) && (a._autor == b._autor))
                retorno = true;
                
            return retorno;
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }

        public static explicit operator string(Libro l)
        {
            return l.Mostrar(l);
        }
    }
}
