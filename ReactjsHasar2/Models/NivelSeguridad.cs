using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class NivelSeguridad
    {
        [Key]
        public int NivelPermiso { get; set; }
        public string Descripcion { get; set; }
    }
}
