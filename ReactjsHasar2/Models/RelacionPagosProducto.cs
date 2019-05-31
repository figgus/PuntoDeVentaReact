using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class RelacionPagosProducto
    {
        public int ID { get; set; }
        public int NumFolio { get; set; }
        public int IdMedioPago { get; set; }
        public int Monto { get; set; }
    }
}
