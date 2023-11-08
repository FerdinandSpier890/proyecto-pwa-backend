using API.PWA.Empresas.Domain;
using API.PWA.Empresas.Interfaces;
using AutoMapper;
using MediatR;

namespace API.PWA.Empresas.Aplicacion
{
    public class InsertEmpresasQueryHandler : IRequestHandler<InsertEmpresasQuery, Guid>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public InsertEmpresasQueryHandler(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(InsertEmpresasQuery request, CancellationToken cancellationToken)
        {
            var empresaDto = request.Empresa;
            var nuevaEmpresa = _mapper.Map<Empresa>(empresaDto);

            // Inserta la nueva empresa en la base de datos
            _empresaRepository.Insert(nuevaEmpresa);

            // Devuelve el ID de la nueva empresa
            return nuevaEmpresa.IdEmpresa;
        }
    }
}
