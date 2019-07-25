using Microsoft.EntityFrameworkCore;
using ReactjsHasar2.Models;
using ReactjsHasar2.Models.ModelsDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.DAL
{
    public class ContextoBDMysql: DbContext
    {
        public DbSet<libro_iva> libro_iva { get; set; }
        public DbSet<plu> plu { get; set; }
        public DbSet<Hist_plu> Hist_plu { get; set; }
       // public DbSet<Categoria_Producto> Categoria_Producto { get; set; }
        public DbSet<Subfuncion> subfuncion { get; set; }
        public DbSet<Zeta> Zeta { get; set; }
        public DbSet<Hist_fn> Hist_fn { get; set; }
        public DbSet<TipoDocumento> Tipo_Documento { get; set; }
        public DbSet<NivelSeguridad> Nivel_Seguridad { get; set; }
        public DbSet<Operador> Operador { get; set; }
        public DbSet<Detalle> Detalle { get; set; }
        public DbSet<AnulacionesVentas> AnulacionesVentas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=192.168.100.59;Database=puntodeventa;Uid=hasar;Pwd=1234;Convert Zero Datetime=True");
        }

        public DbSet<ReactjsHasar2.Models.Historico_rendicion> Historico_rendicion { get; set; }

        public DbSet<ReactjsHasar2.Models.FoliosLocal> FoliosLocal { get; set; }

        public DbSet<ReactjsHasar2.Models.Solicitud> Solicitud { get; set; }

        public DbSet<ReactjsHasar2.Models.MediosDePago> MediosDePago { get; set; }

        public DbSet<ReactjsHasar2.Models.Ajustes> Ajustes { get; set; }

        public DbSet<ReactjsHasar2.Models.RelacionPagosProducto> RelacionPagosProducto { get; set; }


    }
}

