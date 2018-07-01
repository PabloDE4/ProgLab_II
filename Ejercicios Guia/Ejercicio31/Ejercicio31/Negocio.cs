using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio31
{
    public class Negocio
    {
        #region Atributos
        private string nombre;
        private Queue<Cliente> clientes;
        private PuestoAtencion caja;
        #endregion

        #region Constructores
        private Negocio() {
            this.clientes = new Queue<Cliente>();
            this.caja = new PuestoAtencion(Puesto.Caja1);
        }

        public Negocio(string nomb) : this() {
            this.nombre = nomb;
        }
        #endregion

        #region Propiedades
        public Cliente Cliente
        {
            get
            {
                if (this.clientes.Count != 0)
                {
                    return this.clientes.Dequeue();
                }
                else
                    return null;
            }
            set
            {
                bool respuesta = this + value;
            }
        }
        #endregion

        #region Sobrecarga
        public static bool operator ==(Negocio n, Cliente c)
        {
            bool retorno = false;

            foreach (Cliente item in n.clientes)
            {
                if (item == c)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Negocio n, Cliente c)
        {
            return !(n == c);
        }

        public static bool operator +(Negocio n, Cliente c) {

            bool retorno = false;

            if (n != c)
            {
                n.clientes.Enqueue(c);
                retorno = true;
            }

            return retorno;
        }

        public static bool operator ~(Negocio n) 
        {
            bool retorno = false;

            if (n.caja.Atender(n.Cliente))
            {
                retorno = true;
            }

            return retorno;
        }
        #endregion
    }
}
