using DAL.Entities;
using SkincareShop.Repositories;
using System.Collections.Generic;

namespace SkincareShop.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public List<Product> GetProductsBySkinType(int skinTypeId)
        {
            return _repository.GetProductsBySkinType(skinTypeId);
        }
        public Product GetProductById(int productId)
        {
            return _repository.GetProductById(productId);
        }
    }
}