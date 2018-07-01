using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio16
{
    public class Alumno
    {
        private byte _nota1;
        private byte _nota2;
        private float _notaFinal;

        public string apellido;
        public string nombre;
        public int legajo;


        public Alumno(string nombre, string apellido, int legajo) {
            this.nombre = nombre;
            this.apellido = apellido;
            this.legajo = legajo;
        }

        public void Estudiar(byte notaUno, byte notaDos) {
            this._nota1 = notaUno;
            this._nota2 = notaDos;
        }

        public void CalcularFinal() {

            if (this._nota1 >= 4 && this._nota2 >= 4)
            {
                Random variable = new Random();
                this._notaFinal = variable.Next(0,10);
            }
            else
            {
                this._notaFinal = -1;
            }

        }

        public string Mostrar() {

            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Nombre: " + this.nombre);
            cadena.AppendLine("Apellido: " + this.apellido);
            cadena.AppendLine("Legajo: " + this.legajo);
            cadena.AppendLine("Nota 1: " + this._nota1);
            cadena.AppendLine("Nota 2: " + this._nota2);

            if (this._notaFinal != -1)
            {
                cadena.AppendLine("Nota final: " + this._notaFinal);
            }
            else {
                cadena.AppendLine("Alumno desaprobado");
            }

            return cadena.ToString();
        }
    }
}
