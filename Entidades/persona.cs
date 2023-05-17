using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class persona
    {

        [StringLength(50)]
        public string nombre { get; set; }

        [Key] public int? id { get; set; }

       public int cedula { get; set; }

        [StringLength(100)]
        public string? dirrecion { get; set; }

        [StringLength(100)]
        public string? email { get; set; }   
        [StringLength(20)]
        public string? telefono { get; set;}
        public string contrasena { get; set; }
        public rol rol { get; set; }

    }
}
