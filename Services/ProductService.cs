using Estudo.Models;
using Estudo.Repositories.Interfaces;
using Estudo.Services.Interfaces;

namespace Estudo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Create(Product product)
        {
            if (product.Price <= 0)
                throw new Exception("Invalid price");
            
            _repository.Add(product);
        }

        public IEnumerable<Product> ListAll()
            => _repository.GetAll();

        public Product Search(int id)
            => _repository.GetById(id);
    }
}
