using Estudo.Models;

namespace Estudo.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        void Add(User user);
    }
}
