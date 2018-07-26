using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class MEspecialista:Medico,IMedico
    {
        public enum Especialidad { Traumatologo, Odontologo }

        private Especialidad especialidad;

        public MEspecialista(string nombre, string apellido, Especialidad e)
            : base(nombre, apellido)
        {
            this.especialidad = e;
        }

        public override void Atender()
        {
            Thread.Sleep(tiempoAleatorio.Next(5000, 10000));
        }

        public void IniciarAtencion(Paciente p)
        {
            Thread hilo = new Thread(Atender);
            hilo.Start();
        }
    }
}
