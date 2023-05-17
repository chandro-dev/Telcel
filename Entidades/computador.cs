using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class computador:producto
    {   
        [StringLength(20)]
        public string procesador { get; set;  }

       public string ram { get; set; }
         public string almacenamiento { get; set; }
        [StringLength(50)]
        public string tarjeta_video { get; set; }
        [StringLength(50)]
         public string tarjeta_madre { get; set; }
}
}
