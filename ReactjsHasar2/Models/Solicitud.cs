using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Solicitud
    {
        public int ID { get; set; }
        public int primerFolio { get; set; }
        public int ultimoFolio { get; set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
    }
}
