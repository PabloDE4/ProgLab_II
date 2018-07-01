using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Prestamo
    {
        protected float monto;
        protected DateTime vencimiento;
        
        public float Monto
        {
            get { return this.monto; }
        }

        public DateTime Vencimiento
        {
            get { return this.vencimiento; }
            set 
            {
                if (value.CompareTo(DateTime.Now)>=0)
                {
                    this.vencimiento = value;
                }
                else
                {
                    this.vencimiento = DateTime.Now;
                }
            }
        }

        public Prestamo(float monto, DateTime vencimiento)
        {
            this.monto = monto;
            this.vencimiento = vencimiento;
        }

        public static int OrdenarPorFecha(Prestamo p1, Prestamo p2)
        {
            int retorno = 0;
            if (p1.vencimiento > p2.vencimiento)
                retorno = 1;
            else if (p1.vencimiento < p2.vencimiento)
                retorno = -1;

            return retorno;
        }

        public abstract void ExtenderPlaza(DateTime nuevoVencimiento);

        protected virtual string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Monto      : " + this.monto);
            cadena.AppendLine("Vencimiento: " + this.vencimiento);

            return cadena.ToString();
        }
        
    }
}
