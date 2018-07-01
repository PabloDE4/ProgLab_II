using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio64
{
    public class Negocio
    {
        private Caja caja1;
        private Caja caja2;
        List<string> clientes;

        public Caja Caja1
        {
            get { return this.caja1; }
        }

        public Caja Caja2
        {
            get { return this.caja2; }
        }

        public List<string> Clientes
        {
            get { return this.clientes; }
        }

        public Negocio(Caja c1, Caja c2)
        {
            this.clientes = new List<string>();
            this.caja1 = c1;
            this.caja2 = c2;
        }

        public void AsignarCaja()
        {
            Console.WriteLine("Asignando cajas...\n");

            foreach (string cliente in this.clientes)
            {
                if (caja1.FilaClientes.Count <= caja2.FilaClientes.Count)
                {
                    caja1.FilaClientes.Add(cliente);
                }
                else
                {
                    caja2.FilaClientes.Add(cliente);
                }
                Thread.Sleep(1000);
            }

            Console.WriteLine("Cajas asignadas\n");
        }
        

    }
}
