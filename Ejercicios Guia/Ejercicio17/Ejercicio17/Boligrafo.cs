using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio17
{
    class Boligrafo
    {
        private ConsoleColor color;
        private short tinta;
        const short cantidadTintaMaxima = 100;

        public Boligrafo(ConsoleColor color, short tinta) {
            this.color = color;
            this.tinta = tinta;
        }

        public ConsoleColor GetColor() {
            return this.color;
        }

        public short GetTinta() {
            return this.tinta;
        }

        private void SetTinta(short tinta) {
        
        }

        public void Recargar() {
            this.tinta = cantidadTintaMaxima;
        }

        public bool Pintar(int gasto, out string dibujo) {
            bool retorno = false;

            if (this.tinta >= gasto)
            {
                tinta = (short)(tinta - gasto);
                retorno = true;
            }

            return retorno;
        }
    }
}
