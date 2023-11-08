using API.PWA.Proyectos.Domain;
using API.PWA.Proyectos.Interfaces;
using AutoMapper;
using MediatR;

namespace API.PWA.Proyectos.Aplicacion
{
    public class InsertProyectosQueryHandler : IRequestHandler<InsertProyectosQuery, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMapper _mapper;

        public InsertProyectosQueryHandler(IProyectoRepository proyectoRepository, IMapper mapper)
        {
            _proyectoRepository = proyectoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(InsertProyectosQuery request, CancellationToken cancellationToken)
        {
            var proyectoDto = request.Proyecto;
            var nuevoProyecto = _mapper.Map<Proyecto>(proyectoDto);

            // Inserta la nueva empresa en la base de datos
            _proyectoRepository.Insert(nuevoProyecto);

            // Devuelve el ID de la nueva empresa
            return nuevoProyecto.IdProyecto;
        }
    }
}
