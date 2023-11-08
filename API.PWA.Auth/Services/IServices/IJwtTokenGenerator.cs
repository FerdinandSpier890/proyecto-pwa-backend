using API.PWA.Auth.Models;

namespace API.PWA.Auth.Services.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
