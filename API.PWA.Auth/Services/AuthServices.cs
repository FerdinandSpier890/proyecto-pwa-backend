using API.PWA.Auth.Models.Dto;
using API.PWA.Auth.Models;
using API.PWA.Auth.Services.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using API.PWA.Auth.Data;

namespace API.PWA.Auth.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly AppDbContext _appDbContext;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthServices(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userDtoReturn = _appDbContext.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Email = userDtoReturn.Email,
                        Id = userDtoReturn.Id,
                        Name = userDtoReturn.Name,
                        PhoneNumber = userDtoReturn.PhoneNumber
                    };
                    return string.Empty;
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return "Ocurrio un Error al Registrar los Datos";
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _appDbContext.ApplicationUsers
                .FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            // Contraseña Encontrada
            var token = _jwtTokenGenerator.GenerateToken(user);

            UserDto userDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token,
            };

            return loginResponseDto;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _appDbContext.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }
    }
}
