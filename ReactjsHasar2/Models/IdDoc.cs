using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models.ModelsDTE
{
    public class IdDoc
    {
        public int ID { get; set; }
        public int TipoDTE { get; set; }
        public int Folio { get; set; }
        public DateTime FchEmis { get; set; }

        public int EncabezadoID { get; set; }
        public Encabezado Encabezado { get; set; }
    }
}
