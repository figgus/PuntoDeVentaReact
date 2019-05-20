using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class FoliosLocal
    {
        public int ID { get; set; }
        public int numFolio { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaAsignacion { get; set; }
        public DateTime fechaVenta { get; set; }
        public int estaDisponible { get; set; }
    }
}
