using Microsoft.EntityFrameworkCore;
using SISRESERVAS.Models;

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
