using API.PWA.Empresas.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.PWA.Empresas.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresa { get; set; }

    }
}
