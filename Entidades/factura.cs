using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class factura
    {
        public DateTime fecha { get; set; }
        [Key]
        public int id { get; set; } 
        public DateTime fecha_entrega {  get; set; }
        public double total { get; set; }  
        public string tipo_pago { get; set; }
        public persona cliente { get; set; }
        public List<producto> productos { get; set; }

    }
}
