 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class rol
    {
        [Key]
        public int id { get; set; }
        [StringLength(20)]
        public string Rol { get; set; }
        List<persona> clientes;
    }
}
