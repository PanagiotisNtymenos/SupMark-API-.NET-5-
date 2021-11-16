using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SupMark.Core.DTOs;
using SupMark.Core.Entities;
using SupMark.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupMark.API.Controllers
{
    public class ProductsController : BaseController
    {
        public readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            var products = await _productService.FetchProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Index([FromRoute] int id)
        {
            var product = await _productService.FetchProduct(id);

            return Ok(product);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] ProductDto productDto)
        {
            var product = new Product(productDto.Name, productDto.Image, productDto.Type);

            await _productService.CreateProduct(product);

            return NoContent();
        }

        [HttpPatch("[action]/{id}")]
        public async Task<ActionResult<Product>> Update([FromRoute] int id, [FromBody] ProductDto productDto)
        {
            var product = new Product(productDto.Name, productDto.Image, productDto.Type);

            var model = await _productService.UpdateProduct(id, product);

            if (model == null) return BadRequest();

            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
