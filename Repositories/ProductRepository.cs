using Estudo.Data;
using Estudo.Models;
using Estudo.Repositories.Interfaces;

namespace Estudo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
            => _context.Product.ToList();

        public Product GetById(int id)
            => _context.Product.Find(id);
            
    }
}
