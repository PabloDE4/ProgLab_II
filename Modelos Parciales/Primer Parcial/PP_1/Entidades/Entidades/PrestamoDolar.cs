using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PrestamoDolar:Prestamo
    {
        private PeriocidadDePagos periodicidad;


        public PeriocidadDePagos Periodicidad
        {
            get { return this.periodicidad; }
        }

        public PrestamoDolar(float monto, DateTime vencimiento, PeriocidadDePagos periodicidad)
            : base(monto, vencimiento)
        {
            this.periodicidad = periodicidad;
        }

        public PrestamoDolar(Prestamo prestamo, PeriocidadDePagos periodicidad)
            : this(prestamo.Monto, prestamo.Vencimiento, periodicidad)
        { 
        }

        private float CalcularInteres()
        {
            float TotalPrestamo = 0;

            switch (this.periodicidad)
            {
                case PeriocidadDePagos.Mensual:
                    break;
                case PeriocidadDePagos.Bimestral:
                    break;
                case PeriocidadDePagos.Trimestral:
                    break;
                default:
                    break;
            }

            return TotalPrestamo;

        }

        protected override string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.Mostrar());
            cadena.AppendLine("Costo: " + this.periodicidad);

            return cadena.ToString();
        }
        
    }
}
