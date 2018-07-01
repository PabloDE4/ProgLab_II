using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiazEcheveste.Pablo._2C
{
    public class CajonLlenoException:Exception
    {
        public CajonLlenoException() : base("El Cajon ya esta lleno.")
        {

        }
    }
}
