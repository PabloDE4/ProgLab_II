using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DerivadaDos:Base
    {
        public override string VersionFull
        {
            get { return this.MostrarVersion(); }
        }

        public DerivadaDos():base(1,0)
        { }

        public override string MostrarVersion()
        {
            return base.MostrarVersion();
        }
    }
}
