using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inicio
{
    public class Alumno:Persona
    {
        public short _legajo;
        public ENivelDeEstudio _nivel;

        public Alumno():base()
        {           
        }

        public Alumno(Persona p, short legajo, ENivelDeEstudio nivel) : base(p._nombre,p._apellido,p._raza,p._edad)
        {
            this._legajo = legajo;
            this._nivel = nivel; 
        }
    }
}
