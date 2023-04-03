using Microsoft.EntityFrameworkCore;
using SISRESERVAS.Models;
using System.Drawing;


namespace SISRESERVAS.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
        public DbSet<departamento> Departamentos { get; set; }
        public DbSet<viaje> Viajes { get; set; }
        public DbSet<reserva> Reservas { get; set; }
        public DbSet<usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<departamento>()
                .HasMany(d => d.Viajes)
                .WithOne(v => v.Departamento)
                .HasForeignKey(v => v.DepartamentoId);

            modelBuilder.Entity<viaje>()
                .HasMany(v => v.Reservas)
                .WithOne(r => r.Viaje)
                .HasForeignKey(r => r.ViajeId);

            modelBuilder.Entity<usuario>()
                .HasMany(u => u.Reservas)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioId);
        }
    }
}


