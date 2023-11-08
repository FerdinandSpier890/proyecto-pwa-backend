using API.PWA.Proyectos.Domain;
using API.PWA.Proyectos.Interfaces;
using AutoMapper;
using MediatR;

namespace API.PWA.Proyectos.Aplicacion
{
    public class GetAllProyectosQueryHandler : IRequestHandler<GetAllProyectosQuery, List<ProyectoDto>>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMapper _mapper;

        public GetAllProyectosQueryHandler(IProyectoRepository proyectoRepository, IMapper mapper)
        {
            _proyectoRepository = proyectoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProyectoDto>> Handle(GetAllProyectosQuery request, CancellationToken cancellationToken)
        {
            var proyectos = _proyectoRepository.GetAll(request.EmpresaProyecto);
            return await Task.FromResult(_mapper.Map<List<ProyectoDto>>(proyectos));
        }
    }
}
