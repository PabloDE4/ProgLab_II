using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inicio
{
    public class AlumnoEgresado:Alumno
    {
        public float _promedio;
        public short _promocion;

        public AlumnoEgresado() : base()
        { }

        public AlumnoEgresado(Alumno a, float prom, short promo) : base(((Persona)a), a._legajo, a._nivel)
        {
            this._promedio = prom;
            this._promocion = promo;
        }
    }
}
