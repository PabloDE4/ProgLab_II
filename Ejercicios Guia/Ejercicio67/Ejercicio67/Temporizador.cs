using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio67
{
    sealed class Temporizador
    {
        public delegate void encargadoTiempo();
        public event encargadoTiempo EventoTiempo;

        private Thread hilo;
        private int intervalo;
        
        public bool Activo
        {
            get {
                    bool retorno = false;
                    if (hilo.IsAlive == true)
                    {
                        retorno = true;
                    }
                    return retorno; 
                }
            set {
                    if (hilo.IsAlive == false)
                    {
                        hilo = new Thread(Corriendo);
                        hilo.Start();
                    }
                    else
                    {
                        hilo.Abort();
                    }
                ;}
        }

        public int Intervalo
        {
            get { return this.intervalo; }
            set { this.intervalo = value; }
        }

        public Temporizador(int intervalo)
        {
            this.intervalo = intervalo;
        }

        private void Corriendo()
        {
            EventoTiempo();
            Thread.Sleep(this.Intervalo);
        }
        
    }
}
