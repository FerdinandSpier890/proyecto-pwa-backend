using API.PWA.Empresas.Domain;
using MediatR;

namespace API.PWA.Empresas.Aplicacion
{
    public class GetEmpresasByNameQuery : IRequest<List<EmpresaDto>>
    {
        public string NombreEmpresa { get; }

        public GetEmpresasByNameQuery(string nombreEmpresa)
        {
            NombreEmpresa = nombreEmpresa;
        }
    }
}
