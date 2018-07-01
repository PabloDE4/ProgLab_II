using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Punto11
{
    public class Salon_SalonLlenoEvent
    {
        private string SalonLlenoEvent;

        public Salon_SalonLlenoEvent(string mensaje)
        {
            this.SalonLlenoEvent = mensaje;
        }            

        public string getMensaje(){
            return this.SalonLlenoEvent;
        }

    }
}
