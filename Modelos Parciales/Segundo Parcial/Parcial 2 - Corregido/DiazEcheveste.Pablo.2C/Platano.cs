using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public class Platano:Fruta
    {
        public string paisOrigen;


        /// <summary>
        /// Retorna false
        /// </summary>
        public override bool TieneCarozo
        {
            get { return false; }
        }

        /// <summary>
        /// Retorna platano
        /// </summary>
        public string Tipo
        {
            get { return "Platano"; }
        }


        public Platano() : base()
        { 

        }

        public Platano(ConsoleColor color, float peso, string origen) : base(color, peso)
        {
            this.paisOrigen = origen;
        }

        /// <summary>
        /// Se reutiliza y se agrega campos propios.
        /// </summary>
        /// <returns></returns>
        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Tipo: " + this.Tipo);
            sb.Append(base.FrutaToString());
            sb.AppendLine("Tiene carozo?: " + this.TieneCarozo.ToString());
            sb.AppendLine("Pais de origen: " + this.paisOrigen);

            return sb.ToString();
        }

        /// <summary>
        /// Retorna la representacion de la clase en formato string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}
