using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SupMark.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> FetchProducts();
        Task<Product> FetchProduct(int Id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(int Id, Product product);
        Task<bool> DeleteProduct(int Id);
    }
}
