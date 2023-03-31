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
    }
}
