using API.PWA.Proyectos.Domain;
using MediatR;

namespace API.PWA.Proyectos.Aplicacion
{
    public class InsertProyectosQuery : IRequest<Guid>
    {
        public ProyectoDto Proyecto { get; set; }

        public InsertProyectosQuery(ProyectoDto proyecto) 
        {
            Proyecto = proyecto;
        }
    }
}
