using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Models
{
    public class Context : DbContext

    {
        public Context(DbContextOptions<Context> options) : base(options) { 
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<WebApplication1.Models.Grupo>? Grupo { get; set; }
        public DbSet<WebApplication1.Models.Luminaria>? Luminaria { get; set; }
        }

}
