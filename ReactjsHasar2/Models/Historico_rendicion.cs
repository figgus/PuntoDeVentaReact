using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Historico_rendicion
    {
        public int ID { get; set; }
        public int NroPOS { get; set; }
        public int NroZeta { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoFn { get; set; }
        public int CodigoSubFn { get; set; }
        public int CodigoOperador { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Monto { get; set; }
        public double Rendido { get; set; }
        public double Recibido { get; set; }
        public double Retirado { get; set; }
        public double CtaCte { get; set; }
        public double Diferencia { get; set; }
        public int CodigoTurno { get; set; }

    }
}
