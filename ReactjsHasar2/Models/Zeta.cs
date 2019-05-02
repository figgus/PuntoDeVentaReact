using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Zeta
    {
        public int NroPOS { get; set; }
        [Key]
        public int NroZeta { get; set; }
        public DateTime Fecha { get; set; }
    }
}
