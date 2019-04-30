using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Detalle
    {
        public int ID { get; set; }
        public int EncabezadoID { get; set; }
        public Encabezado Encabezado { get; set; }

        public int numeroLinea { get; set; }
        public string CodigoItem { get; set; }
        public string NombreItem { get; set; }
        public string DescripcionItem { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string UserIngreso { get; set; }
        public int MontoSinIva { get; set; }
        public int MontoConIva { get; set; }
        public int Cantidad { get; set; }
    }
}
