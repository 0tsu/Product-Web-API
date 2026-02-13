using Product_Web_API.Models;

namespace Estudo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DataCreate { get; set; } = DateTime.Now;

        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
