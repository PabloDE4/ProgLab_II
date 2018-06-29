using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_2
{
    public class Calculador
    {
        private int acumulador;
        public string usuario;

        public Calculador(string usuario){

            this.acumulador = 0;
            this.usuario = usuario;

        }

        public void acumular(string binario) {

            acumulador += Conversor.BinarioEntero(binario);

        }

        public string getResultadoBinario() {

            return Conversor.EnteroBinario(acumulador);

        }

        public int getResultadoEntero() {

            return acumulador;

        }

    }
}
