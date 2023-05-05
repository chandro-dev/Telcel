using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class producto
    {
            public string nombre { get; set; }
            public int  precio { get; set; }
            public int cantidad { get; set; }
            public bool Envio { get; set; }
            public int descuento { get; set; }
            public string marca { get; set; }

    }
}
