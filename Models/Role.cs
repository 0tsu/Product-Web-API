using Product_Web_API.Models;

namespace Estudo.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
    
}
