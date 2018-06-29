using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    public class Producto
    {
        protected string codigoDeBarra;
        protected string _marca;
        protected float _precio;

        public Producto(string marca, string codigo, float precio) {
            this._marca = marca;
            this.codigoDeBarra = codigo;
            this._precio = precio;
        }

        public string GetMarca() {
            return this._marca;
        }

        public float GetPrecio() {
            return this._precio;
        }

        public string MostrarProducto(Producto p) {

            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Marca: " + p._marca);
            cadena.AppendLine("Codigo de barra: " + p.codigoDeBarra);
            cadena.AppendLine("Precio: " + p._precio);

            return cadena.ToString();
        }

        public static explicit operator string(Producto p)
        {
            return p.codigoDeBarra.ToString();
        }

        public static bool operator ==(Producto p1, Producto p2) {

            bool retorno = false;

            if (p1._marca == p2._marca && p1.codigoDeBarra == p2.codigoDeBarra)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Producto p1, string marca)
        {
            bool retorno=false;

            if (p1._marca == marca)
            {
                retorno = true;
            }

            return retorno;  
        }

        public static bool operator !=(Producto p1, string marca)
        {
            return !(p1 == marca);
        }


    }
}
