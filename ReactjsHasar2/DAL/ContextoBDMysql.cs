using Microsoft.EntityFrameworkCore;
using ReactjsHasar2.Models;
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=localhost;Database=puntodeventa;Uid=joaquin;Pwd=1234;Convert Zero Datetime=True");
        }
    }
}
