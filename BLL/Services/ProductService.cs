using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<Product> SearchProduct(string searchText)
        {
            return _productRepository.SearchProduct(searchText);
        }

        public Product AddProduct(Product product)
        {
            ValidateProduct(product);
            return _productRepository.AddProduct(product);
        }

        public Product? GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }



        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product? UpdateProduct(Product product)
        {
            ValidateProduct(product);
            return _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        private void ValidateProduct(Product product)
        {
            var validationContext = new ValidationContext(product);
            Validator.ValidateObject(product, validationContext, validateAllProperties: true);
        }
    }
}
