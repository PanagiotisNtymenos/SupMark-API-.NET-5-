using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SupMark.Core.Entities;
using SupMark.Core.Entities.Common;
using SupMark.Core.Entities.Partials;
using SupMark.Core.Extensions;
using SupMark.Infrastructure.DataAccess;
using SupMark.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly SupMarkDbContext _context;
        public ProductService(SupMarkDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> FetchProducts()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> FetchProduct(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == product.Id);
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {

            if (product.AllPropertiesAreNull()) return null;

            var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToUpdate != null)
            {

                if (productToUpdate.Name != product.Name && !string.IsNullOrEmpty(product.Name)) productToUpdate.Name = product.Name;
                if (productToUpdate.Image != product.Image) productToUpdate.Image = product.Image;
                if (productToUpdate.Type != product.Type) productToUpdate.Type = product.Type;
                if (productToUpdate.Notes != product.Notes) productToUpdate.Notes = product.Notes;

                await _context.SaveChangesAsync();

                return productToUpdate;
            }

            return null;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return false;

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
