using System.Text.Json;
using EShop.Domain;

namespace EShop.DAL
{
    public class JsonProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get()
        {
            var json = File.ReadAllText("Products.json");
            var products = JsonSerializer.Deserialize<Product[]>(json);

            return products;
        }
    }
}
