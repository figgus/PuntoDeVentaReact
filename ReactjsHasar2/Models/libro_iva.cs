using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class libro_iva
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public int NumHojas { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string RespIVA { get; set; }
        public double NetoGravado { get; set; }
        public double NetoExento { get; set; }
        public double MontoPercepcionIIBB { get; set; }
        public double MontoPercepcionIVA { get; set; }
        public double MontoImpuestoInterno { get; set; }
        public double MontoImpuestoVideo { get; set; }
        public double RedondeoBaseImponible { get; set; }
        public double TotalOperacion { get; set; }
        public int NroZeta { get; set; }
    }
}
