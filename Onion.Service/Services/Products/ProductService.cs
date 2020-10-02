using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Onion.Data.Modes.Products;
using Onion.Repository.DataTransfer;
using Onion.Service.Dto;

namespace Onion.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;
      

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
           
        }

        public ProductDto GetById(int id)
            => MaProductToProductDto(_productRepository.GetById(id));

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var currentProduct = _productRepository.GetAll();
            foreach (var item in currentProduct)
            {
                yield return MaProductToProductDto(item);
            }
            
        }

        public void AddProduct(ProductDto createProduct)
        {
            var currentProduct = _productRepository.GetAll().Where(c => c.Name == createProduct.Name);
            if (currentProduct.Any())
                throw new Exception("Duplicate Product Name");
            createProduct.DateCreated= DateTime.Now;
            _productRepository.Add(MaProductDtoToProduct(createProduct));
        }



        public void UpdateProduct(ProductDto editedProduct)
        {
            var currentProduct = _productRepository.GetById(editedProduct.Id);
            if (currentProduct is null)
                throw new Exception("Product Not Found");
            if (editedProduct.Name != currentProduct.Name)
                if (_productRepository.GetAll().Where(c => c.Name == editedProduct.Name).Any())
                    throw new Exception("Duplicate Product Name");
            currentProduct.Name = editedProduct.Name;
            currentProduct.Description = editedProduct.Description;
            currentProduct.Price = currentProduct.Price;
            currentProduct.DateUpdated =DateTime.Now;
            _productRepository.Update(currentProduct);
        }

        public void DeleteProduct(int id)
        {
            var currentProduct = _productRepository.GetById(id);
            if (currentProduct is null)
                throw new Exception("Product Not Found");

            _productRepository.Delete(currentProduct);
        }

        public IEnumerable<ProductDto> GetByName(string name)
        {
            var currentProduct = _productRepository.GetAll().Where(c=>c.Name== name);
            foreach (var item in currentProduct)
            {
                yield return MaProductToProductDto(item);
            }
        }   

        public ProductDto MaProductToProductDto(Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description =  product.Description,
                DateCreated = product.DateCreated,
                Price = product.Price
            };
        }

        

        public Product MaProductDtoToProduct(ProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
               Price = productDto.Price,
               DateCreated = productDto.DateCreated,
               DateUpdated = DateTime.Now
            };
        }

       
    }
}
