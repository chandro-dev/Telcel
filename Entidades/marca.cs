using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class marca
    {

        [Key]public int id { get; set; }
        [StringLength(50)]
        public string nombre_marca { get; set; }

    }
}
