using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models.ModelsDTE
{
    public class Emisor
    {
        public int ID { get; set; }

        public string RUTEmisor { get; set; }
        public string RznSoc { get; set; }
        public string GiroEmis { get; set; }
        public string Acteco { get; set; }
        public string CdgSIISucur { get; set; }
        public string DirOrigen { get; set; }
        public string CmnaOrigen { get; set; }
        public string CiudadOrigen { get; set; }

        public int EncabezadoID { get; set; }
        public Encabezado Encabezado { get; set; }
    }
}
