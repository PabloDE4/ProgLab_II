using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public abstract class Fruta
    {
        protected ConsoleColor _color;
        protected float _peso;

        public abstract bool TieneCarozo
        {
            get;
        }

        public Fruta()
        { }

        public Fruta(ConsoleColor color, float peso)
        {
            this._color = color;
            this._peso = peso;
        }

        /// <summary>
        /// Retorna la representacion de la clase en formato string.
        /// </summary>
        /// <returns></returns>
        protected virtual string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Color: " + this._color.ToString());
            sb.AppendLine("Peso: " + this._peso);

            return sb.ToString();
        }

    }
}
