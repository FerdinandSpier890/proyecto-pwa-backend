using API.PWA.Proyectos.Aplicacion;
using API.PWA.Proyectos.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.PWA.Proyectos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProyectosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProyectosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProyectoDto>>> GetAllProyecto(Guid empresaProyecto)
        {
            var query = new GetAllProyectosQuery(empresaProyecto);
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> InsertEmpresa([FromBody] ProyectoDto proyectoDto)
        {
            var insertQuery = new InsertProyectosQuery(proyectoDto);
            var proyectoId = await _mediator.Send(insertQuery);
            return Ok(proyectoId);
        }
    }
}
