using Estudo.DTOs;
using Estudo.Models;

namespace Estudo.Services.Interfaces
{
    public interface IAuthService
    {
        TokenResponseDto Login(LoginDto dto);
    }
}
