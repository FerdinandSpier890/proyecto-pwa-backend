using API.PWA.Auth.Models.Dto;
using API.PWA.Auth.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.PWA.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        protected ResponseDto _responseDto;

        public AuthApiController(IAuthServices authServices)
        {
            _authServices = authServices;
            _responseDto = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registro([FromBody] RegistrationRequestDto model)
        {
            var message = await _authServices.Register(model);

            if (!string.IsNullOrEmpty(message))
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = message;
                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authServices.Login(model);

            if (loginResponse.User == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "El Nombre de Usuario o la Contraseña son Incorrectas";
                return BadRequest(_responseDto);
            }
            _responseDto.Data = loginResponse;
            return Ok(_responseDto);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var rolResponse = await _authServices.AssignRole(model.Email, model.Role.ToUpper());

            if (!rolResponse)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "La Asignación del Rol Falló";
                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }
    }
}
