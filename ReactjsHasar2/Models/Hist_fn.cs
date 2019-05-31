using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Hist_fn
    {
        [Key]
        public int ID { get; set; }
        public int? CodPLU { get; set; }
        public int NroPOS { get; set; }
        public int NroZeta { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoFn { get; set; }
        public int CodigoSubFn { get; set; }
        public int CodigoOperador { get; set; }
        public double Cantidad { get; set; }
        public double Monto { get; set; }
        public double MontoIVA { get; set; }
        public double MontoII { get; set; }
        public double PorcImpInt { get; set; }
        public double PorcIVA { get; set; }
        public int CodigoTurno { get; set; }
        public string FechaUltAct { get; set; }

        
        public int? CategoriaFk { get; set; }
        public int? numeroFolio { get; set; }
    }
}
