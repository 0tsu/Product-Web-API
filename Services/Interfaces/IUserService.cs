using Estudo.DTOs;

namespace Estudo.Services.Interfaces
{
    public interface IUserService
    {
        void Register(UserCreateDto dto);
        UserLoginResponseDto Login(UserLoginDto dto);
    }
}
