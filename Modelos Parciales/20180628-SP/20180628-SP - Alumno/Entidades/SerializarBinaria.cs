using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Excepciones;

namespace Entidades
{
    public class SerializarBinaria : IArchivos<Votacion>
    {
        public Votacion Leer(string nombre)
        {
            try
            {
                Votacion votacionLeida;

                FileStream fs;                 
                BinaryFormatter ser;      
                fs = new FileStream(nombre, FileMode.Open);

                ser = new BinaryFormatter();

                votacionLeida = (Votacion)ser.Deserialize(fs);

                fs.Close();
                return votacionLeida;
            }
            catch (Exception e)
            {
                throw new ErrorArchivoException("Error al leer el archivo",e);
            }
        }

        public bool Guardar(string nombre, Votacion objeto)
        {
            try
            {
                FileStream fs;  	 
                BinaryFormatter ser;  

                fs = new FileStream(nombre, FileMode.Create);
                ser = new BinaryFormatter();
                ser.Serialize(fs, objeto);
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new ErrorArchivoException("Error al intentar guardar el archivo", e);
            }
        }

        
    }
}
