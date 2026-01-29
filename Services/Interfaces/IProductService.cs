using Estudo.Models;

namespace Estudo.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> ListAll();
        Product Search(int id);
        void Create(Product product);
    }
}
