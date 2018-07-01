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

        public MEspecialista(string nombre, string apellido, Especialidad e) : base(nombre, apellido)
        {
            this.especialidad = e;
        }

        protected override void Atender()
        {
            Thread.Sleep(Medico.tiempoAleatorio.Next(5000, 10000));
            base.finalizarAtencion();
        }

        public void iniciarAtencion(Paciente p)
        {
            base.pacienteActual = p;
            Thread hilo = new Thread(this.Atender);
            hilo.Start();
        }
    }
}
