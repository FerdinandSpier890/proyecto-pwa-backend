using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.PWA.Proyectos.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        // Método estatico que se va a utilizar como método extendido
        public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder webApplicationBuilder)
        {
            var settingsSection = webApplicationBuilder.Configuration.GetSection("ApiSettings");
            var secret = settingsSection.GetValue<string>("Secret");
            var issuer = settingsSection.GetValue<string>("Issuer");
            var audience = settingsSection.GetValue<string>("Audience");

            // Codificamos el Secret
            var key = Encoding.ASCII.GetBytes("BHJAGDYWEBNMASNHDASUITE-AJKADHSWYESAA-7328YDASKJH7823TE");
            webApplicationBuilder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateAudience = true,
                };
            });

            return webApplicationBuilder;
        }
    }
}
