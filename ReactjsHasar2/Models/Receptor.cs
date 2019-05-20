using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models.ModelsDTE
{
    public class Receptor
    {
        public int ID { get; set; }
        public string RUTRecep { get; set; }
        public string RznSocRecep { get; set; }
        public string GiroRecep { get; set; }
        public string DirRecep { get; set; }
        public string CmnaRecep { get; set; }
        public string CiudadRecep { get; set; }

        public int EncabezadoID { get; set; }
        public Encabezado Encabezado { get; set; }
    }
}
