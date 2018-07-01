using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CentralTelefonica
{
    public class Centralita : IGuardar<string>
    {
        #region atributos
        private List<Llamada> listaDeLlamada;
        protected string razonSocial;
        protected string rutaDeArchivo;
        #endregion

        #region propiedades

        public float GananciasPorLocal
        {
            get { return this.CalcularGanancia(Llamada.TipoLlamada.Local); }
        }

        public float GananciasPorProvincial
        {
            get { return this.CalcularGanancia(Llamada.TipoLlamada.Provincial); }
        }

        public float GananciasPorTotal
        {
            get { return this.CalcularGanancia(Llamada.TipoLlamada.Todas); }
        }

        public List<Llamada> Llamadas
        {
            get { return this.listaDeLlamada; }
        }

        public string RutaDeArchivo
        {
            get { return this.rutaDeArchivo; }
            set { this.rutaDeArchivo = value; }
        }
        
        
        #endregion

        #region metodos
        public Centralita() 
        {
            this.listaDeLlamada = new List<Llamada>();
            this.RutaDeArchivo = "Bitacora.txt";
        }

        public Centralita(string nombreEmpresa):this()
        {
            this.razonSocial = nombreEmpresa;
        }

        private float CalcularGanancia(Llamada.TipoLlamada tipo)
        {
            float ganancia = 0;
            foreach (Llamada llamada in this.listaDeLlamada)
            {
                switch (tipo)
                {
                    case Llamada.TipoLlamada.Local:
                        if (llamada is Local)
                        {
                            ganancia = ganancia + ((Local)llamada).CostoLlamada;
                        }
                        break;

                    case Llamada.TipoLlamada.Provincial:
                        if (llamada is Provincial)
                        {
                            ganancia = ganancia + ((Provincial)llamada).CostoLlamada;
                        }
                        break;

                    case Llamada.TipoLlamada.Todas:
                        if (llamada is Local)
                        {
                            ganancia = ganancia + ((Local)llamada).CostoLlamada;
                        }
                        else if (llamada is Provincial)
                        {
                            ganancia = ganancia + ((Provincial)llamada).CostoLlamada;
                        }

                        break;
                }
            }

            return ganancia;
        }

        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this.listaDeLlamada.Add(nuevaLlamada);
        }

        public void OrdenarLlamadas()
        {
            this.listaDeLlamada.Sort(Llamada.OrdenarPorDuracion);
        }

        public string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("\nRazon Social: {0}", this.razonSocial);
            cadena.AppendFormat("\nGanancia Total: {0}", this.GananciasPorTotal);
            cadena.AppendFormat("\nGanancia Local: {0}", this.GananciasPorLocal);
            cadena.AppendFormat("\nGanancia Provincial: {0}", this.GananciasPorProvincial);
            cadena.Append("\nLLAMADAS:");
            foreach (Llamada llamada in this.listaDeLlamada)
            {
                cadena.Append("\n---------------------------------------");
                cadena.AppendFormat(llamada.ToString());
            }

            return cadena.ToString();
        }

        public static bool operator ==(Centralita c, Llamada llamada)
        {
            bool retorno = false;
            foreach (Llamada l in c.listaDeLlamada)
            {
                if (l == llamada)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Centralita c, Llamada llamada)
        {
            return !(c == llamada);
        }

        public static Centralita operator +(Centralita c, Llamada nuevaLlamada)
        {
            if (c != nuevaLlamada)
            {
                c.AgregarLlamada(nuevaLlamada);

                if (!c.Guardar())
                {
                    throw new FallaLogException("No se pudo guardar.", "Centralita", "Operator +");
                }
            }
            else
            {
                throw new CentralitaException("Ya existe la llamada", c.GetType().Name, "Operator +");
            }
            return c;
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public bool Guardar()
        {
            try
            {
                StreamWriter file = new StreamWriter(this.RutaDeArchivo);
                file.WriteLine(this.ToString());
                file.Close();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public string Leer()
        {
            StreamReader file = new StreamReader(this.RutaDeArchivo);
            string retorno = file.ReadToEnd();
            file.Close();
            return retorno;
        }
        #endregion
    }
}
