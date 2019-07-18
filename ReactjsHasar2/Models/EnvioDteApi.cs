using ReactjsHasar2.Models.ModelsDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class EnvioDteApi
    {
        public List<Detalle> detalles { get; set; }
        public int numFolio { get; set; }
        public int tipoDocumento { get; set; }
        public int? TpoDocLiq { get; set; }//solo para liquidacion-factura
        public int? IndTraslado { get; set; }//solo guia de despacho
        public string CmnaDest { get; set; }//obligatorio solo en la guia de despacho
        public string RutCliente { get; set; }
        public int NumSucursal { get; set; }
        public int NumCaja { get; set; }
        public int? numFolioReferencia { get; set; }
        public int? tipoDocumentoRef { get; set; }
        public int? CodRef { get; set; }
        public int? FmaPago { get; set; }
        public int? CdgTraslado { get; set; }

    }
}
