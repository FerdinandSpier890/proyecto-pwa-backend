using API.PWA.Empresas.Domain;
using API.PWA.Empresas.Interfaces;

namespace API.PWA.Empresas.Infraestructure
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmpresaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Empresa> GetAll()
        {
            return _dbContext.Empresa.ToList();
        }

        public void Insert(Empresa empresa)
        {
            _dbContext.Empresa.Add(empresa);
            _dbContext.SaveChanges();
        }

        public Empresa GetByName(string nombreEmpresa)
        {
            return _dbContext.Empresa.FirstOrDefault(e => e.NombreEmpresa == nombreEmpresa);
        }
    }
}
