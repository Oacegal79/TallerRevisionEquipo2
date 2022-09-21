using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class ContextDb : DbContext
    {
        public virtual DbSet<Mecanico> Mecanicos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<JefeOperaciones> JefesOperaciones { get; set; }
        public virtual DbSet<Notificacion> Notificaciones { get; set; }
        public virtual DbSet<Repuesto> Repuestos { get; set; }
        public virtual DbSet<Revision> Revisiones { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            try
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Server=tcp:taller.database.windows.net,1433;Initial Catalog=bd_tallertic_grupo8equipo2;Persist Security Info=False;User ID=taller;Password=Misiontic2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Ocurrió un error en el OnConfiguring");
            }

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder){
            modelBuilder.Entity<Revision>()
            .HasOne(b => b.Mecanico)
            .WithOne(c => c.Revision);
        }

    }
}