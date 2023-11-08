using API.PWA.Empresas.Aplicacion;
using API.PWA.Empresas.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.PWA.Empresas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpresasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpresaDto>>> GetAllEmpresa()
        {
            var query = new GetAllEmpresasQuery();
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> InsertEmpresa([FromBody] EmpresaDto empresaDto) 
        {
            var insertQuery = new InsertEmpresasQuery(empresaDto);
            var empresaId = await _mediator.Send(insertQuery);
            return Ok(empresaId);
        }

        /*
        [HttpGet("ByName/{nombreEmpresa}")]
        public async Task<ActionResult<List<EmpresaDto>>> GetEmpresasByName(string nombreEmpresa)
        {
            var query = new GetEmpresasByNameQuery(nombreEmpresa);
            var empresas = await _mediator.Send(query);

            if (empresas.Count == 0)
            {
                return NotFound();
            }

            return Ok(empresas);
        }
        */

    }
}
