using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Hist_plu
    {
        [Key]
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoPLU { get; set; }
        public int NroPos { get; set; }
        public double Cantidad { get; set; }
        public double Monto { get; set; }
        public double MontoIVA { get; set; }
        public double MontoII { get; set; }
        public double Costo { get; set; }
        public double PorcImpInt { get; set; }
        public int PorcBonif { get; set; }
        public double PorcIVA { get; set; }
    }
}
