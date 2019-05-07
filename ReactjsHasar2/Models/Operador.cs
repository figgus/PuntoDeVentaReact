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
        public string Apellido { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public string NroLegajo { get; set; }
        public string CodigoDoc { get; set; }
        public string NroDocumento { get; set; }
        public string Pais { get; set; }
        public int NivelPermiso { get; set; }
        public string Clave { get; set; }
        public string Foto { get; set; }
        public string FechaUltAct { get; set; }
        public int fIsPlayero { get; set; }
        public string fEsJefe { get; set; }
        
    }
}
