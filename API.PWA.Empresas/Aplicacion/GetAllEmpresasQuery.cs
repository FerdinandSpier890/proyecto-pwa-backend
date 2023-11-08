using API.PWA.Empresas.Domain;
using MediatR;

namespace API.PWA.Empresas.Aplicacion
{
    public class GetAllEmpresasQuery : IRequest<List<EmpresaDto>>
    {
        public GetAllEmpresasQuery()
        {
            
        }
    }
}
