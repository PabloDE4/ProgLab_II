using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio20
{
    public class Pesos
    {
        #region Atributos
        private static float cotizRespectoDolar;
        private double cantidad;
        #endregion

        #region Constructores
        static Pesos()
        {
            Pesos.cotizRespectoDolar = 0.049566f;
        }

        public Pesos(double cantidad) {
            this.cantidad = cantidad;
        }

        public Pesos(double cantidad, float cotizacion)
            : this(cantidad)
        {
            Pesos.cotizRespectoDolar = cotizacion;
        }
        #endregion

        public static float GetCotizacion()
        {
            return Pesos.cotizRespectoDolar;
        }

        public double GetCantidad()
        {
            return this.cantidad;
        }

        #region Sobrecarga
        public static explicit operator Dolar(Pesos p)
        {
            return new Dolar(p.cantidad / Pesos.GetCotizacion());
        }

        public static explicit operator Euro(Pesos p)
        {
            return (Euro)((Dolar)p);
        }

        public static implicit operator Pesos(double d)
        {
            Pesos retorno = new Pesos(d);
            return retorno;
        }

        public static Pesos operator -(Pesos p, Dolar d)
        {
            Pesos retorno = new Pesos(p.cantidad - ((Pesos)d).cantidad);
            return retorno;
        }

        public static Pesos operator -(Pesos p, Euro e)
        {
            Pesos retorno = new Pesos(p.cantidad - ((Pesos)e).cantidad);
            return retorno;
        }

        public static Pesos operator +(Pesos p, Dolar d)
        {
            Pesos retorno = new Pesos(p.cantidad + ((Pesos)d).cantidad);
            return retorno;
        }

        public static Pesos operator +(Pesos p, Euro e)
        {
            Pesos retorno = new Pesos(p.cantidad + ((Pesos)e).cantidad);
            return retorno;
        }

        public static bool operator ==(Pesos p, Dolar d)
        {
            return (p == (Pesos)d);
        }

        public static bool operator !=(Pesos p, Dolar d)
        {
            return !(p == d);
        }

        public static bool operator ==(Pesos p, Euro e)
        {
            return (p == (Pesos)e);
        }

        public static bool operator !=(Pesos p, Euro e)
        {
            return !(p == e);
        }

        public static bool operator ==(Pesos p1, Pesos p2)
        {
            return p1.cantidad == p2.cantidad;
        }

        public static bool operator !=(Pesos p1, Pesos p2)
        {
            return !(p1 == p2);
        }
        #endregion


    }
}
