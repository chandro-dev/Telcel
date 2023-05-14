 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    internal interface IServicios<t>
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS0169 // El campo 'IServicios<t>.list' nunca se usa
        private static List<t> list
#pragma warning restore CS0169 // El campo 'IServicios<t>.list' nunca se usa
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
;
        public bool add(t e);
        public bool remove(t e);
        public bool update(t e);
    }
}
