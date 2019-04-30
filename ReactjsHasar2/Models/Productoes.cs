using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Productoes
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string CodBarra { get; set; }
        public string Sku { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> FamiliaID { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal Venta { get; set; }
        public decimal Margen { get; set; }
        public decimal Codigo_d { get; set; }
        public string Codigo_s { get; set; }
        public decimal Aux_d { get; set; }
        public string Aux_s { get; set; }
        public Nullable<int> EntidadID { get; set; }
        //public string Imagen { get; set; }
        public System.DateTime FecIngreso { get; set; }
        public string UsuIngreso { get; set; }
        public System.DateTime FecModifica { get; set; }
        public string UsuModifica { get; set; }
    }
}
