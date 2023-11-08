using Microsoft.AspNetCore.Identity;

namespace API.PWA.Auth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
