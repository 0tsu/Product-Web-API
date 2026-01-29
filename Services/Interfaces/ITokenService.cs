using Estudo.Models;

namespace Estudo.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
