using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SupMark.Core.Entities;
using SupMark.Core.Entities.Partials;
using SupMark.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Services.Implementations.Mock
{
    public class MockProductService : IProductService
    {
        private List<Product> Products = new List<Product>
        {
                new Product("Προϊόν 1","https://www.bastiaanmulder.nl/wp-content/uploads/2013/11/dummy-image-square.jpg","Ετικέτα 1"),
                new Product("Προϊόν 2","https://www.bastiaanmulder.nl/wp-content/uploads/2013/11/dummy-image-square.jpg","Ετικέτα 2"),
                new Product("Προϊόν 3","https://www.bastiaanmulder.nl/wp-content/uploads/2013/11/dummy-image-square.jpg","Ετικέτα 3"),
                new Product("Προϊόν 4","https://www.bastiaanmulder.nl/wp-content/uploads/2013/11/dummy-image-square.jpg","Ετικέτα 4"),
        };

        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FetchProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> FetchProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(int productId, Product product)
        {
            throw new NotImplementedException();

        }
    }
}
