using API.PWA.Empresas.Domain;
using API.PWA.Empresas.Interfaces;
using AutoMapper;
using MediatR;

namespace API.PWA.Empresas.Aplicacion
{
    public class GetEmpresasByNameQueryHandler : IRequestHandler<GetEmpresasByNameQuery, List<EmpresaDto>>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public GetEmpresasByNameQueryHandler(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<List<EmpresaDto>> Handle(GetEmpresasByNameQuery request, CancellationToken cancellationToken)
        {
            var empresas = _empresaRepository.GetByName(request.NombreEmpresa);
            return await Task.FromResult(_mapper.Map<List<EmpresaDto>>(empresas));
        }
    }
}
