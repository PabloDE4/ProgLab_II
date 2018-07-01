using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio64
{
    public class Caja
    {
        private List<string> filaClientes;
        
        public List<string> FilaClientes
        {
            get { return this.filaClientes; }
        }

        public Caja()
        {
            this.filaClientes = new List<string>();
        }

        public void AtenderClientes()
        {
            foreach (string cliente in filaClientes)
            {
                Console.WriteLine(Thread.CurrentThread.Name + cliente);
                Thread.Sleep(2000); 
            }
        }
    }
}
