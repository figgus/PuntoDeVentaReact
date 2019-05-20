using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models.ModelsDTE
{
    public class Totales
    {
        public string MntNeto { get; set; }
        public int TasaIVA { get; set; }
        public int IVA { get; set; }
        public int MntTotal { get; set; }

        public int EncabezadoID { get; set; }
        public Encabezado Encabezado { get; set; }
    }
}
