using System;
using System.Collections.Generic;
using Onion.Service.Dto;

namespace Onion.Service.Services.Products
{
   public interface IProductService
    {
         IEnumerable<ProductDto> GetAllProducts();
         ProductDto GetById(int id);
         void AddProduct(ProductDto createProduct);
         void UpdateProduct(ProductDto editedProduct);
         void DeleteProduct(int id);
        IEnumerable<ProductDto> GetByName(string name);

    } 
    
}
