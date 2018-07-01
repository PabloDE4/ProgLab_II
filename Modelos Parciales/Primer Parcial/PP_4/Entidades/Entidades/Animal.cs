using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Animal
    {
        protected int _cantidadPatas;
        protected static Random _distanciaRecorrida;
        protected int _velocidadMaxima;
        
        
        public int CantidadDePatas
        {
            get { return this._cantidadPatas; }
            set {
                    if (value <= 4 && value > 0)
                    {
                        this._cantidadPatas = value;
                    }
                    else
                    {
                        this._cantidadPatas = 4;
                    }
                }
        }
        
        public int VelocidadMaxima
        {
            get { return this._velocidadMaxima; }
            set {
                    if (value <= 60 && value > 0)
                    {
                        this._velocidadMaxima = value;
                    }
                    else
                    {
                        this._velocidadMaxima = 60;
                    }
                }
        }
        
        private int DistanciaRecorrida
        {
            get { return _distanciaRecorrida.Next(10,this.VelocidadMaxima); }
        }

        static Animal()
        {
            _distanciaRecorrida = new Random();
        }

        public Animal(int cantidadPatas, int velocidadMax)
        {
            this._cantidadPatas = cantidadPatas;
            this._velocidadMaxima = velocidadMax;
        }

        public string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("Cantidad de patas: " + this._cantidadPatas);
            cadena.AppendLine("Velocidad Maxima: " + this._velocidadMaxima);
            cadena.AppendLine("Distancia recorrida: " + this.DistanciaRecorrida);

            return cadena.ToString(); 
        }

    }
}
