using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models.ModelsDTE
{
    public class Referencia
    {
        public int ID { get; set; }
        public int NroLinRef { get; set; }
        public string TpoDocRef { get; set; }
        public int IndGlobal { get; set; }
        public string FolioRef { get; set; }
        public string RUTOtr { get; set; }
        public string IdAdicOtr { get; set; }
        public string FchRef { get; set; }
        public int CodRef { get; set; }
        public string RazonRef { get; set; }

        public int EncabezadoID { get; set; }
        public Encabezado Encabezado { get; set; }
    }
}
