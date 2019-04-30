using Microsoft.EntityFrameworkCore;
using ReactjsHasar2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.DAL
{
    public class ContextoBD : DbContext
    {

        public DbSet<Productoes> Productoes { get; set; }
        public DbSet<Encabezado> Encabezadoes { get; set; }
        public DbSet<Detalle> Detalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = CVRBACKUP\\MSSQLSERVER2014;initial catalog=SodimacTest; User Id = rosario; Password = Hasar1102; ");
        }

    }

   // public DbSet<Usuarios> Encabezadoes { get; set; }

    
}
