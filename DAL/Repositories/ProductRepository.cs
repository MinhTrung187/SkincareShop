using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository
    {
        private readonly SkincareShopContext _context;

        public ProductRepository()
        {
            _context = new SkincareShopContext();
        }

        public List<Product> SearchProduct(string searchText)
        {
            var searchProducts = _context.Products.Where(p => p.Name.Contains(searchText) && !p.IsDeleted).ToList();
            return searchProducts;
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product? GetProductById(int productId)
        {
            return _context.Products.Include(p => p.SkinType).FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.SkinType).Where(p => !p.IsDeleted).ToList();
        }

        public Product? UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductId);
            if (existingProduct == null)
            {
                return null;
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
            return existingProduct;
        }
        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);

            product.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
