using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Encabezado
    {
        public int ID { get; set; }
        public string VersionDTE { get; set; }
        public string RUTEmisor { get; set; }
        public string RutReceptor { get; set; }
        public string Trasnporte { get; set; }
        public string NombreEmisor { get; set; }
        public string NombreReceptor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string UserIngreso { get; set; }
        //public virtual ICollection<Detalle> Detalles { get; set; }
        //public virtual ICollection<SubTotal> SubTotales { get; set; }
        public int MntCancel { get; set; }

        //public Referencia IDReferencia { get; set; }
        //public Referencia Referencia { get; set; }
    }
}
