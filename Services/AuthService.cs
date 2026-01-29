using Estudo.DTOs;
using Estudo.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Estudo.Repositories.Interfaces;
using Estudo.Repositories;
using Estudo.Models;

namespace Estudo.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public TokenResponseDto Login(LoginDto dto)
        {
            var user = _userRepository.GetByEmail(dto.Email);

            if (user == null)
                throw new Exception("User or Password is invalid.");
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("User or Password is invalid.");

            return new TokenResponseDto
            {
                Token = _tokenService.CreateToken(user),
                Expiration = DateTime.UtcNow.AddHours(2)
            };
        }
    }
}
