using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio20
{
    public class Dolar
    {
        #region atributos
        private double cantidad;
        private static float cotizRespectoDolar;
        #endregion

        #region Constructores
        static Dolar()
        {
          Dolar.cotizRespectoDolar = 1;
        }

        public Dolar(double cantidad){
            this.cantidad = cantidad;
        }

        public Dolar(double cantidad, float cotizacion) : this(cantidad) {
            Dolar.cotizRespectoDolar = cotizacion;
        }
        #endregion


        public static float GetCotizacion()
        {
            return Dolar.cotizRespectoDolar;
        }

        public double GetCantidad()
        {
            return this.cantidad;
        }

        #region Sobrecarga
        public static explicit operator Euro(Dolar d) {
            return new Euro(d.cantidad * Euro.GetCotizacion());
        }

        public static explicit operator Pesos(Dolar d)
        {
            return new Pesos(d.cantidad * Pesos.GetCotizacion());
        }

        public static implicit operator Dolar(double d)
        {
            Dolar retorno = new Dolar(d);
            return retorno;
        }

        public static Dolar operator -(Dolar d, Euro e)
        {            
            Dolar retorno = new Dolar(d.cantidad - ((Dolar)e).cantidad);
            return retorno;
        }

        public static Dolar operator -(Dolar d, Pesos p)
        {
            Dolar retorno = new Dolar(d.cantidad - ((Dolar)p).cantidad);
            return retorno;
        }

        public static Dolar operator +(Dolar d, Euro e)
        {
            Dolar retorno = new Dolar(d.cantidad + ((Dolar)e).cantidad);
            return retorno;
        }

        public static Dolar operator +(Dolar d, Pesos p)
        {
            Dolar retorno = new Dolar(d.cantidad + ((Dolar)p).cantidad);
            return retorno;
        }

        public static bool operator ==(Dolar d, Euro e)
        {
            return d == (Dolar)e;
        }

        public static bool operator !=(Dolar d, Euro e)
        {
            return !(d == e);
        }

        public static bool operator ==(Dolar d, Pesos p)
        {
            return d == (Dolar)p;
        }

        public static bool operator !=(Dolar d, Pesos p)
        {
            return !(d == p);
        }

        public static bool operator ==(Dolar d1, Dolar d2)
        {
            return d1.cantidad == d2.cantidad;
        }

        public static bool operator !=(Dolar d1, Dolar d2)
        {
            return !(d1 == d2);
        }
        #endregion
    }
}
