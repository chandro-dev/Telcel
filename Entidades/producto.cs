using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class producto
    {
            [Key]
            [NotNull]
            public int id { get; set; } 
            [StringLength(50)]    
            public string nombre { get; set; }
            public int  precio { get; set; }
            public int cantidad { get; set; }
            public bool Envio { get; set; }
            public int descuento { get; set; }            
            public marca marca { get; set; }
            public byte[] imagen { get; set; }
    }
}
