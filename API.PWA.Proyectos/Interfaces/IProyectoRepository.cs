using API.PWA.Proyectos.Domain;

namespace API.PWA.Proyectos.Interfaces
{
    public interface IProyectoRepository
    {
        List<Proyecto> GetAll(Guid empresaProyecto);

        void Insert(Proyecto proyecto);
    }
}
