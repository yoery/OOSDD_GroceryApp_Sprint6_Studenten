using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            // Optionally: validate required fields
            if (string.IsNullOrWhiteSpace(item.name))
                throw new ArgumentException("Product name is required.", nameof(item));
            if (item.Price < 0 || item.Price > 999.99m)
                throw new ArgumentOutOfRangeException(nameof(item.Price), "Price must be between 0 and 999.99.");
            if (item.stock < 0)
                throw new ArgumentOutOfRangeException(nameof(item.stock), "Stock cannot be negative.");

            // Add product via repository
            return _productRepository.Add(item);
        }

        public Product? Delete(Product item)
        {
            throw new NotImplementedException();
        }

        public Product? Get(int id)
        {
            throw new NotImplementedException();
        }

        public Product? Update(Product item)
        {
            return _productRepository.Update(item);
        }
    }
}
