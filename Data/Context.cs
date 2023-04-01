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

        public DbSet<usuario> usuario { get; set; }
        public DbSet<departamento> departamento { get; set; }
        public DbSet<viaje> viaje { get; set; }
        public DbSet<reserva> reserva { get; set; }

 
    }
}
