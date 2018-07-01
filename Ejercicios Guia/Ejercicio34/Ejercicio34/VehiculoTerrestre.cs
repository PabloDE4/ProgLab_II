using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio34
{
    public class VehiculoTerrestre
    {
        protected short _cantidadRuedas;
        protected short _cantidadPuertas;
        protected Colores _color;
        protected short _cantidadMarchas;

        public VehiculoTerrestre(short cantidadRuedas, short cantidadPuertas, Colores color)
        {
            this._cantidadRuedas = cantidadRuedas;
            this._cantidadPuertas = cantidadPuertas;
            this._color = color; 
        }

        public VehiculoTerrestre(short cantidadRuedas, short cantidadPuertas, Colores color, short cantidadMarchas) : this(cantidadRuedas, cantidadPuertas, color) 
        {
            this._cantidadMarchas = cantidadMarchas;   
        }
    }
}
