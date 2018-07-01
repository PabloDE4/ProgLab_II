using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades.Punto11
{
    public delegate void DelegadoSalon(object obj, Salon_SalonLlenoEvent e);

    public class Salon<T>
    {
        public List<T> _elementos;
        public int _capacidad;

        private Salon()
        {
            this._elementos = new List<T>();
        }

        public Salon(int capacidad):this()
        {
            this._capacidad = capacidad;
        }

        public static Salon<T> operator +(Salon<T> c, T f)
        {
            if (c._elementos.Count < c._capacidad)
            {
                c._elementos.Add(f);
            }
            else
            {
                throw new Entidades.Punto10.NoAgregaException("El salon esta lleno");
                c.SalonLlenoEvent(c, new Salon_SalonLlenoEvent("El salon esta lleno"));
            }
            return c;

        }

        public event DelegadoSalon SalonLlenoEvent;

    }

}
