using API.PWA.Empresas.Domain;
using API.PWA.Empresas.Interfaces;
using AutoMapper;
using MediatR;

namespace API.PWA.Empresas.Aplicacion
{
    public class GetAllEmpresasQueryHandler : IRequestHandler<GetAllEmpresasQuery, List<EmpresaDto>>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public GetAllEmpresasQueryHandler(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper; 
        }

        public async Task<List<EmpresaDto>> Handle(GetAllEmpresasQuery request, CancellationToken cancellationToken)
        {
            var empresas = _empresaRepository.GetAll();
            return await Task.FromResult(_mapper.Map<List<EmpresaDto>>(empresas));
        }
    }

}
