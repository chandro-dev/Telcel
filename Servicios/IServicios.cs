 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    internal interface IServicios<t>
    {
        private static List<t> list
;
        public bool add(t e);
        public bool remove(t e);
        public bool update(t e);
    }
}
