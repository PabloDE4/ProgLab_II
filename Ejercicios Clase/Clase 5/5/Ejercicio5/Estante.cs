using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    public class Estante
    {
        private Producto[] _productos;
        private int ubicacionEstante;

        private Estante(int capacidad) {
            this._productos = new Producto[capacidad];
        }

        public Estante(int capacidad, int ubicacion) : this(capacidad) {
            this.ubicacionEstante = ubicacion;
        }

        public static string MostrarEstante(Estante e){

            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Ubicacion: " + e.ubicacionEstante);

            foreach (Producto p in e._productos)
            {
                cadena.AppendLine(p.MostrarProducto(p));
            }

            return cadena.ToString();
        }

        public Producto[] GetProductos()
        {
            return this._productos;
        }

        public static bool operator ==(Estante e, Producto p) {
            bool retorno = false;

            for (int i = 0; i < e._productos.Length; i++)
            {
                if (!(object.ReferenceEquals(e._productos[i], null)) && e._productos[i] == p)
                {                    
                    retorno = true;
                }                
            }

            return retorno;
        }

        public static bool operator !=(Estante e, Producto p) {
            return !(e == p);
        }

        public static bool operator +(Estante e, Producto p) {
            bool retorno = false;

            if (e != p)
            {
                for (int i = 0; i < e._productos.Length; i++)
                {
                    if (object.ReferenceEquals(e._productos[i], null))
                    {
                        e._productos[i]=p;
                        retorno = true;
                        break;
                    }
                }                
            }

            return retorno;
        }

        public static Estante operator -(Estante e, Producto p) {

            for (int i = 0; i < e._productos.Length; i++)
            {
                if (e._productos[i] == p)
                {
                    e._productos[i] = null;
                    break;
                }
            }  

            return e;
        }
 
    }
}
