using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Subfuncion
    {
        //pendiente
        [Key]
        public int ID { get; set; }

        public int CodigoFn { get; set; }
        public int CodigoSubFn { get; set; }
        public string AliasSubFn { get; set; }
        public string DescSubFn { get; set; }
        public int NivelPermiso { get; set; }
        public string FechaUltAct { get; set; }
    }
}
