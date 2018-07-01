using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio30
{
    public enum TipoCompetencia { F1, Motocross }

    public class Competencia<T>
        where T : VehiculoCarrera
    {
        private short cantidadCompetidores;
        private short cantidadVueltas;
        private List<T> competidores;
        private TipoCompetencia tipo;
        
        public short CantidadCompetidores
        {
            get { return this.cantidadCompetidores; }
            set { this.cantidadCompetidores = value; }
        }

        public short CantidadVueltas
        {
            get { return this.cantidadVueltas; }
            set { this.cantidadVueltas = value; }
        }

        public List<T> Competidores
        {
            get { return this.competidores; }
        }
        

        public TipoCompetencia Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public T this[int i]
        {
            get
            {
                return this.competidores[i];
            }
        }

        private Competencia()
        {
            this.competidores = new List<T>();
        }

        public Competencia(short cantidadVueltas, short cantidadCompetidores, TipoCompetencia tipo)
            : this()
        {
            this.cantidadVueltas = cantidadVueltas;
            this.cantidadCompetidores = cantidadCompetidores;
            this.tipo = tipo;
        }

        public static bool operator ==(Competencia<T> c, T a)
        {
            bool retorno = false;

            foreach (VehiculoCarrera auto in c.competidores)
            {
                if (auto == a)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Competencia<T> c, T a)
        {
            return !(c == a);
        }

        public static bool operator +(Competencia<T> c, T a)
        {
            bool retorno = false;
            Random cantidadCombustible = new Random();
            switch (c.Tipo)
            {
                case TipoCompetencia.F1:
                        if (c.competidores.Count < c.CantidadCompetidores && c != a)
                        {
                            if (a is AutoF1)
                            {
                                retorno = true;
                                a.EnCompetencia = true;
                                a.VueltasRestantes = c.CantidadVueltas;
                                a.CantidadCombustible = (short)cantidadCombustible.Next(15, 100);
                                c.competidores.Add(a);
                            }
                        }                    
                    break;

                case TipoCompetencia.Motocross:

                        if (c.competidores.Count < c.CantidadCompetidores && c != a)
                        {
                            if (a is MotoCross)
                            {
                                retorno = true;
                                a.EnCompetencia = true;
                                a.VueltasRestantes = c.CantidadVueltas;
                                a.CantidadCombustible = (short)cantidadCombustible.Next(15, 100);
                                c.competidores.Add(a);
                            }
                        }
                    
                    break;
            }

            return retorno;
        }

        public static bool operator -(Competencia<T> c, T a)
        {
            bool retorno = false;

            if (c.competidores.Contains(a))
            {
                retorno = true;
                a.EnCompetencia = false;
                a.VueltasRestantes = 0;
                a.CantidadCombustible = 0;
                c.competidores.Remove(a);
            }
            return retorno;
        }

        public string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("***** " + this.Tipo + " *****");
            cadena.AppendLine("Cantidad de Competidores: " + this.CantidadCompetidores);
            cadena.AppendLine("Cantidad de vueltas: " + this.CantidadVueltas);
            cadena.AppendLine("\n--- Competidores ---");
            foreach (VehiculoCarrera v in this.competidores)
            {
                cadena.AppendLine(v.MostrarDatos());
            }
            return cadena.ToString();
        }
    }
}
