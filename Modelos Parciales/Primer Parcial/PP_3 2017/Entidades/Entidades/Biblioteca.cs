using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {

        private int _capacidad;
        private List<Libro> _libros;

        private Biblioteca()
        {
            _libros = new List<Libro>();
        }

        public Biblioteca(int capacidad)
            : this()
        {
            this._capacidad = capacidad;
        }
        
        public double PrecioDeManuales
        {
            get { return (double)ELibro.Manual; }
        }

        public double PrecioDeNovelas
        {
            get { return (double)ELibro.Novela; }
        }

        public double PrecioTotal
        {
            get { return (double)ELibro.Ambos; }
        }
        

        public static string Mostrar(Biblioteca e)
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("\n***** Listado de Libros *****\n");
            foreach (Libro l in e._libros)
            {
                cadena.AppendLine(l.Mostrar(l));
            }
            cadena.AppendLine("Capacidad: " + e._capacidad);

            return cadena.ToString();
        }

        public static implicit operator Biblioteca(int capacidad)
        {
            Biblioteca aux = new Biblioteca(capacidad);
            return aux;
        }

        public static bool operator ==(Biblioteca e, Libro l)
        {
            bool retorno = false;

            foreach (Libro libro in e._libros)
            {
                if (libro == l)
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Biblioteca e, Libro l)
        {
            return !(e == l);
        }

        public static Biblioteca operator +(Biblioteca e, Libro l)
        {
            if (e != l)
            {
                e._libros.Add(l);
            }

            return e;
        }

        private double ObtenerPrecio(ELibro tipoLibro)
        {
            double ganancia = 0;
            foreach (Libro libro in this._libros)
            {
                switch (tipoLibro)
                {
                    case ELibro.Manual:
                        if (libro is Manual)
                        {
                            ganancia = ganancia + this.PrecioDeManuales;
                        }
                        break;

                    case ELibro.Novela:
                        if (libro is Novela)
                        {
                            ganancia = ganancia + this.PrecioDeNovelas;
                        }
                        break;

                    default:
                        ganancia = ganancia + this.PrecioTotal;

                        break;
                }
            }

            return ganancia;
 
        }


    }
}
