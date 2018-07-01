using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio31
{
    public class PuestoAtencion
    {
        #region Atributos
        private static int numeroActual;
        private Puesto puesto;
        #endregion

        #region Propiedades
        public static int NumeroActual
        {
            get
            {
                numeroActual++;
                return numeroActual;
            }
        }
        #endregion

        #region Constructores
        static PuestoAtencion() 
        {
            PuestoAtencion.numeroActual = 0;
        }

        public PuestoAtencion(Puesto puesto) 
        {
            this.puesto = puesto;
        }
        #endregion

        #region Metodos
        public bool Atender(Cliente cli) {

            bool retorno = false;

            if (cli != null)
            {
                System.Threading.Thread.Sleep(2000);
                retorno = true;
            }
            return retorno;
        }
        #endregion
    }
}
