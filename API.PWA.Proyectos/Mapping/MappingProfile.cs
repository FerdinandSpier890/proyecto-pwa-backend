using API.PWA.Proyectos.Domain;
using AutoMapper;

namespace API.PWA.Proyectos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Proyecto, ProyectoDto>().ReverseMap();
        }
    }
}
