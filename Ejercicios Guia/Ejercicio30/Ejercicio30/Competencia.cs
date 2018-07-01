using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio30
{
    public enum TipoCompetencia { F1, Motocross }

    public class Competencia
    {
        private short cantidadCompetidores;
        private short cantidadVueltas;
        private List<VehiculoCarrera> competidores;
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

        public TipoCompetencia Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public VehiculoCarrera this[int i]
        {
            get
            {
                return this.competidores[i];
            }
        }

        private Competencia()
        {
            this.competidores = new List<VehiculoCarrera>();
        }

        public Competencia(short cantidadVueltas, short cantidadCompetidores, TipoCompetencia tipo)
            : this()
        {
            this.cantidadVueltas = cantidadVueltas;
            this.cantidadCompetidores = cantidadCompetidores;
            this.tipo = tipo;
        }

        public static bool operator ==(Competencia c, VehiculoCarrera a)
        {
            bool retorno = false;

            foreach (AutoF1 auto in c.competidores)
            {
                if (auto == a)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Competencia c, VehiculoCarrera a)
        {
            return !(c == a);
        }

        public static bool operator +(Competencia c, VehiculoCarrera a)
        {
            bool retorno = false;
            Random cantidadCombustible = new Random();

            if (c.competidores.Count < c.cantidadCompetidores && c != a)
            {
                retorno = true;
                a.EnCompetencia = true;
                a.VueltasRestantes = c.cantidadVueltas;
                a.CantidadCombustible = (short)cantidadCombustible.Next(15, 100);
                c.competidores.Add(a);
            }

            return retorno;
        }

        public static bool operator -(Competencia c, VehiculoCarrera a)
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
