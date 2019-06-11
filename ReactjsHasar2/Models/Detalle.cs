using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models.ModelsDTE
{
    public class Detalle
    {
        public int ID { get; set; }

        public int NroLinDet { get; set; }
        public CdgItem CdgItem { get; set; }
        public string NmbItem { get; set; }
        public string DscItem { get; set; }
        public int QtyItem { get; set; }
        public int PrcItem { get; set; }
        public int MontoItem { get; set; }

        
    }
}
