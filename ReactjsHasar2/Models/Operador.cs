using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Models
{
    public class Operador
    {
        [Key]
        public int CodigoOperador { get; set; }
        public int Apellido { get; set; }
        public int ApellidoMaterno { get; set; }
        public int Nombre { get; set; }
        public int Telefono { get; set; }
        public int Direccion { get; set; }
        public int Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public int Provincia { get; set; }
        public int NroLegajo { get; set; }
        public int CodigoDoc { get; set; }
        public int NroDocumento { get; set; }
        public int Pais { get; set; }
        public int NivelPermiso { get; set; }
        public int Clave { get; set; }
        public int Foto { get; set; }
        public int FechaUltAct { get; set; }
        public int fIsPlayero { get; set; }
        public int fEsJefe { get; set; }
        
    }
}
