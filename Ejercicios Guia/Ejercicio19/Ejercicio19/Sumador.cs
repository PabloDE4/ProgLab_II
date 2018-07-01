using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19
{
    public class Sumador
    {
        private int cantidadSumas;

        public Sumador():this(0)
        {
        }

        public Sumador(int cantidadSumas) {
            this.cantidadSumas = cantidadSumas;
        }

        public long Sumar(long a, long b) {
            this.cantidadSumas++;
            return a + b;
        }

        public string Sumar(string a, string b) {
            return string.Concat(a,b);
        }

        public static explicit operator int(Sumador s)
        {
            return s.cantidadSumas;
        }

        public static long operator +(Sumador s1, Sumador s2)
        {
            return (long)(s1.cantidadSumas + s2.cantidadSumas);
        }

        public static bool operator |(Sumador s1, Sumador s2)
        {
            return s1.cantidadSumas == s2.cantidadSumas;             
        }

    }
}
