using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models.ModelsDTE
{
    public class Subtotal
    {
        public int ID { get; set; }
        public int NroSTI { get; set; }
        public string GlosaSTI { get; set; }//Título del Subtotal 
        public int OrdenSTI { get; set; }//Ubicación para Impresión
        public int SubTotNetoSTI { get; set; }
        public int SubTotIVASTI { get; set; }//Valor del IVA del Subtotal 
        public int SubTotAdicSTI { get; set; }
        public int SubTotExeSTI { get; set; }
        public int ValSubtotSTI { get; set; }
        public int LineasDeta { get; set; }

        public int EncabezadoID { get; set; }
        public Encabezado Encabezado { get; set; }
    }
}
