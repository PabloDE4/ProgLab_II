using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio34
{
    public class Automovil:VehiculoTerrestre
    {
        protected int _cantidadPasajeros;

        public Automovil(short cantidadRuedas, short cantidadPuertas, Colores color, short cantidadMarchas, int cantidadPasajeros)
            : base(cantidadRuedas, cantidadPuertas, color, cantidadMarchas)
        {
            this._cantidadPasajeros = cantidadPasajeros;        
        }
    }
}
