using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Punto6F
{
    public interface IDeserializar
    {
        bool Xml(string path, out AlumnoEgresado a);
    }
}
