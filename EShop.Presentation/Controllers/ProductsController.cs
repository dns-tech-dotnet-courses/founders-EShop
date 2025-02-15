using Microsoft.AspNetCore.Mvc;
using EShop.Application;

namespace EShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductHandler _handler;
        
        public ProductsController(ProductHandler productHandler)
        {
            _handler = productHandler;
        }

        [HttpGet("getAll")]
        public IEnumerable<ProductDto> Get([FromQuery] decimal? priceFilter, [FromQuery] string? priceSortOrder)
        {
            var products = _handler.Get();

            if (priceFilter is not null)
                products = products.Where(p => p.Price <= priceFilter);

            if (!string.IsNullOrEmpty(priceSortOrder))
            {
                products = priceSortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase)
                    ? products.OrderByDescending(p => p.Price)
                    : products.OrderBy(p => p.Price);
            }

            var productsDto = products.Select(p => new ProductDto(p.Name, p.Price));
            return productsDto;
        }

        [HttpGet("getById")]
        public IEnumerable<ProductDto> GetById([FromQuery] int id)
        {
            var products = _handler.GetById(id);
            return products.Select(product => new ProductDto(product.Name, product.Price));
        }

    }
}
