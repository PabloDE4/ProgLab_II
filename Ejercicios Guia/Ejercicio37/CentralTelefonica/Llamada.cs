using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralTelefonica
{
    public abstract class Llamada
    {
        public enum TipoLlamada { Local, Provincial, Todas }

        #region atributos
        protected float _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;
        #endregion

        #region propiedades

        // Tendrá definida la propiedad de sólo lectura CostoLlamada que también será abstracta
        public abstract float CostoLlamada
        {
            get;
        }        

        public float Duracion
        {
            get { return this._duracion; }
        }

        public string NroDestino
        {
            get { return this._nroDestino; }
        }

        public string NroOrigen
        {
            get { return this._nroOrigen; }
        }
        #endregion

        #region constructor
        public Llamada(float duracion, string nroDestino, string nroOrigen) 
        {
            this._duracion = duracion;
            this._nroDestino = nroDestino;
            this._nroOrigen = nroOrigen;
        }
        #endregion

        #region metodos
        protected virtual string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Duracion      : " + this._duracion);
            cadena.AppendLine("Numero Destino: " + this._nroDestino);
            cadena.AppendLine("Numero Origen : " + this._nroOrigen);

            return cadena.ToString();
        }

        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2) 
        {
            int retorno = 0;
            if (llamada1.Duracion > llamada2.Duracion)
                retorno = 1;
            else if (llamada1.Duracion < llamada2.Duracion)
                retorno = -1;
            return retorno;
        }

        public static bool operator ==(Llamada l1, Llamada l2)
        {
            return (l1.Equals(l2) && l1._nroDestino == l2.NroDestino && l1.NroOrigen == l2.NroOrigen);
        }

        public static bool operator !=(Llamada l1, Llamada l2)
        {
            return !(l1 == l2);
        }
        #endregion

    }
}
