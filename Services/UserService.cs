using Estudo.DTOs;
using Estudo.Models;
using Estudo.Repositories.Interfaces;
using Estudo.Services.Interfaces;

namespace Estudo.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public UserLoginResponseDto Login(UserLoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);
            if(user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid credentials");
            }

            var token = _tokenService.CreateToken(user);

            return new UserLoginResponseDto
            {
                Token = token
            };
        }

        public void Register(UserCreateDto dto)
        {
            var userExists = _repository.GetByEmail(dto.Email);
            if (userExists != null)
            {
                throw new Exception("Email already registered");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            _repository.Add(user);
        }
    }
}
