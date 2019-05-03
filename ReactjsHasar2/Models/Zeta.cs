using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Zeta
    {
        [Key]
        public int ID { get; set; }
        public int NroPOS { get; set; }
        public int NroZeta { get; set; }
        public DateTime Fecha { get; set; }
    }
}
