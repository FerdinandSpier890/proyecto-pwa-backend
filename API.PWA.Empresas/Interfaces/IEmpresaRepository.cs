using API.PWA.Empresas.Domain;

namespace API.PWA.Empresas.Interfaces
{
    public interface IEmpresaRepository
    {
        List<Empresa> GetAll();

        void Insert(Empresa empresa);

        Empresa GetByName(string nombreEmpresa);
    }
}
