using API.PWA.Proyectos.Domain;
using MediatR;

namespace API.PWA.Proyectos.Aplicacion
{
    public class GetAllProyectosQuery : IRequest<List<ProyectoDto>>
    {
        public Guid EmpresaProyecto {  get; set; }

        public GetAllProyectosQuery(Guid empresaProyecto)
        {
            EmpresaProyecto = empresaProyecto;
        }
    }
}
