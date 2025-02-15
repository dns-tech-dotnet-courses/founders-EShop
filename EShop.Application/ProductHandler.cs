using EShop.Domain;
using FluentResults;

namespace EShop.Application
{
    public class ProductHandler
    {
        private readonly IProductRepository _productRepository;
        
        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<IEnumerable<Product>>> Get()
        {
            var productsResult = await _productRepository.Get();
            return productsResult;
        }

        public async Task<Result<IEnumerable<Product>>> GetById(int? id)
        {
            var products = await _productRepository.Get();
            var filteredProducts = products.Value.Where(product => product.Id == id);
            return Result.Ok(filteredProducts);
        }
    }
}
