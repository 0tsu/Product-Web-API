using Estudo.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
