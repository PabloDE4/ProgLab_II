using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public interface ISerializable
    {
        string RutaArchivo
        { get; set; }

        bool SerializarXml();
        bool DeSerializarXml();
    }
}
