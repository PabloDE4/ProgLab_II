using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio31
{
    public class Cliente
    {
        #region Atributos
        private string nombre;
        private int numero;
        #endregion

        #region Constructores
        public Cliente(int num) {
            this.numero = num;
        }

        public Cliente(int num, string nomb):this(num) {
            this.nombre = nomb;
        }
        #endregion

        #region Propiedades
        public int Numero
        {
            get { return this.numero; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        #endregion

        #region Sobrecarga
        /*
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            bool retorno = false;

            if (c1.numero == c2.numero)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }
         */
        #endregion
        
        
    }
}
