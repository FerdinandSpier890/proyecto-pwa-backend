using API.PWA.Proyectos.Domain;
using API.PWA.Proyectos.Interfaces;

namespace API.PWA.Proyectos.Infraestructure
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProyectoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Proyecto> GetAll(Guid empresaProyecto)
        {
            return _dbContext.Set<Proyecto>()
                .Where(a => a.EmpresaProyecto == empresaProyecto)
                .ToList();
        }

        public void Insert(Proyecto proyecto)
        {
            _dbContext.Proyecto.Add(proyecto);
            _dbContext.SaveChanges();
        }
    }
}
