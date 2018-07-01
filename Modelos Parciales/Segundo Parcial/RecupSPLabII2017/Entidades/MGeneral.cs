using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class MGeneral:Medico,IMedico
    {
        protected override void Atender()
        {
            Thread.Sleep(Medico.tiempoAleatorio.Next(1500, 2200));
            base.finalizarAtencion();
        }

        public MGeneral(string nombre, string apellido) : base(nombre, apellido)
        {

        }

        public void iniciarAtencion(Paciente p)
        {
            base.pacienteActual = p;
            Thread hilo = new Thread(this.Atender);
            hilo.Start();
        }
    }
}
