using API.PWA.Auth.Models.Dto;

namespace API.PWA.Auth.Services.IServices
{
    public interface IAuthServices
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);

        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        Task<bool> AssignRole(string email, string roleName);
    }
}
