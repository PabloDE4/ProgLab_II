using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public class Biblioteca
    {
        private int _capacidad;
        private List<Libro> _libros;

        public enum ELibro
        { Manual, Novela, Ambos }

        private Biblioteca()
        {
            this._libros = new List<Libro>();
        }

        private Biblioteca(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

                
        /*
         public double PrecioDeManual
        {
            get { return this.PrecioDeManual(Manual); }
        } 
         */
         

        public static string Mostrar(Biblioteca e)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("CAPACIDAD: " + e._capacidad);

            foreach (Libro l in e._libros)
            {
                cadena.AppendLine(l.ToString());
            }

            return cadena.ToString();
        }


        /*
        public double ObetenerPrecio(ELibro tipo)
        {
            double resultado=0;
            foreach (Libro l in this._libros)
            {
                switch (tipo)
                {
                    case ELibro.Manual:
                        if (l is Novela)
                           
                        return ;
                        
                    case ELibro.Manual:
                        if (l is Manual)
                            
                        return ;
                        
                    case ELibro.Ambos:

                        return ;
                }
            }
        }
         */

        public static bool operator ==(Biblioteca e, Libro l)
        {
            bool retorno=false;
            foreach (Libro lib in e._libros)
            {
                if (lib == l)
                {
                    retorno= true;
                }
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
                e._libros.Add(l);
            return e;
        }

        public static implicit operator Biblioteca(int capacidad)
        {
            Biblioteca auxiliar = new Biblioteca(capacidad);
            return auxiliar;
        }
    }
}
