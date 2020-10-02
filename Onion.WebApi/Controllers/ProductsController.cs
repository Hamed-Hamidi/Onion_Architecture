using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Data.Modes.Products;
using Onion.Service.Dto;
using Onion.Service.Services.Products;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDto> Get()
            => _productService.GetAllProducts();


        [HttpGet("GetById/{id}")]
        public ProductDto GetById(int id)
            => _productService.GetById(id);

        [HttpGet("GetByName")]
        public IEnumerable<ProductDto> GetByName(string name)
          => _productService.GetByName(name);

        [HttpPost]
        public void Post(ProductDto product)
            => _productService.AddProduct(product);

        [HttpPut]
        public void Put(ProductDto editedProduct)
            => _productService.UpdateProduct(editedProduct);


        [HttpDelete("{id}")]
        public void Delete(int id)
            => _productService.DeleteProduct(id);

    }
}