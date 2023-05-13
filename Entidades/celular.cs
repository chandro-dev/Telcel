using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class celular : producto
    {
        [StringLength(5)]
        public string camara { get; set; }
        public string almacenamiento { get; set; }
         [StringLength(500)]
        public string descripcion { get; set; }
        public string ram { get; set; }
    }
}
