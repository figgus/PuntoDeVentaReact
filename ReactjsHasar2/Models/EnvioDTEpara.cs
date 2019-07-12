using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class EnvioDTEpara
    {
        public List<Hist_plu> detalles { get; set; }
        public int numFolio { get; set; }
        public int tipoDocumento { get; set; }
        public int? TpoDocLiq { get; set; }//solo para liquidacion-factura
        public int? IndTraslado { get; set; }//solo guia de despacho
        public string CmnaDest { get; set; }//obligatorio solo en la guia de despacho

    }
}
