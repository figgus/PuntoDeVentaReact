using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class plu
    {

        [Key]
        public int CodigoPLU { get; set; }
        public int CodigoMedida { get; set; }
        public int CodigoProveedor { get; set; }
        public int CodigoTipo { get; set; }
        public int CodigoSeccion { get; set; }
        public string CodigoScanner { get; set; }
        public string CodigoSProveedor { get; set; }
        public string Descripcion { get; set; }
        public double ValorMedida { get; set; }
        public string CodigoPLUEnvase { get; set; }
        public int fTieneEnvase { get; set; }
        public int fEsEnvase { get; set; }
        public int fEsCombo { get; set; }
        public int fBajaLogica { get; set; }
        public string Foto { get; set; }
        public double Costo { get; set; }
        public double ImpInt { get; set; }
        public double PorcBonif { get; set; }
        public string FechaUltAct { get; set; }//quizas cambiar a datetime
        public int CodigoIVA { get; set; }
        public int CodigoRecDes { get; set; }
        public int TipoImpInt { get; set; }
        public int fImpIntFijo { get; set; }
        public string Flags { get; set; }
        public double Stock_Cantidad { get; set; }
        public double Stock_Combo { get; set; }
        public int fContienePrecio { get; set; }
        public int fPrecioEnDolar { get; set; }
        public int CodigoGrupoImp { get; set; }
        public double Stock_Minimo { get; set; }
        public double CantidadReposicion { get; set; }
        public int UxB { get; set; }
    }
}
