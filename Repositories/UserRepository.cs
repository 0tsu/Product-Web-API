using Estudo.Data;
using Estudo.Models;
using Estudo.Repositories.Interfaces;

namespace Estudo.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _context.User.FirstOrDefault(u => u.Email == email);
        }

    }
}
