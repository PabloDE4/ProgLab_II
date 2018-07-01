using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        protected Autor _autor;
        protected int _cantidadDePaginas = 0;
        protected static Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;

        static Libro()
        {
            _generadorDePaginas = new Random();
        }

        public Libro(string titulo, Autor autor, float precio)
        {
            this._precio = precio;
            this._titulo = titulo;
            this._autor = autor;
        }

        public Libro(float precio, string titulo, string nombre, string apellido) :this(titulo,new Autor(nombre,apellido),precio)
        {

        }

        public int CantidadDePaginas
        {
            get {
                if (this._cantidadDePaginas == 0)
                {
                    this._cantidadDePaginas = _generadorDePaginas.Next(10, 580);
                }
                return _cantidadDePaginas; 
            }
        }
        
        //En realidad es private, pero no puedo mostrarlo...
        public string Mostrar(Libro l)
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Titulo: " + l._titulo);
            cadena.AppendLine(l._autor);
            cadena.AppendLine("Cantidad de paginas: " + l.CantidadDePaginas);
            cadena.AppendLine("Precio: " + l._precio);

            return cadena.ToString(); 
        }

        public static bool operator ==(Libro a, Libro b)
        {
            bool retorno = false;

            if (a._titulo == b._titulo && a._autor == b._autor)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }

        public static explicit operator string(Libro l)
        {
            string datos = "Titulo: " + l._titulo + " Autor: " + l._autor + " Paginas: " + l._cantidadDePaginas + " Precio: " + l._precio;
            return datos;
        }
    }
}
