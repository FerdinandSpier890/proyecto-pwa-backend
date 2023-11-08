using API.PWA.Empresas.Domain;
using MediatR;

namespace API.PWA.Empresas.Aplicacion
{
    public class InsertEmpresasQuery : IRequest<Guid>
    {
        public EmpresaDto Empresa { get; set; }

        public InsertEmpresasQuery(EmpresaDto empresa)
        {
            Empresa = empresa;
        }
    }
}
