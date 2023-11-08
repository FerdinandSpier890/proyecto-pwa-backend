using API.PWA.Proyectos.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.PWA.Proyectos.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Proyecto> Proyecto { get; set; }

    }
}
