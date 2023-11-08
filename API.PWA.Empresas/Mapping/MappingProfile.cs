using API.PWA.Empresas.Domain;
using AutoMapper;

namespace API.PWA.Empresas.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Empresa, EmpresaDto>().ReverseMap();
            //CreateMap<List<Empresa>, List<EmpresaDto>>().ReverseMap();
        }
    }
}
