using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Presentation;

namespace EShop.Application
{
    public class ProductHandler
    {
        private Product[] products =
        [
        new Product { Id = 1, Name = "Iphone", Price = 333 },
        new Product { Id = 2, Name = "Iphone1", Price = 444 },
        new Product { Id = 3, Name = "Iphone2", Price = 555 },
        new Product { Id = 4, Name = "Iphone3", Price = 666 },
        new Product { Id = 5, Name = "Iphone4", Price = 777 }
        ];

        public IEnumerable<Product> Get()
        {
            return products;
        }
    }
}
