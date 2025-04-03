using DAL.Entities;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace SkincareShop.Repositories
{
    public class ProductRepository
    {
        private readonly SkincareShopContext _context;

        public ProductRepository()
        {
            _context = new SkincareShopContext();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Where(p => p.IsDeleted == false)
                .ToList();
        }

        public List<Product> GetProductsBySkinType(int skinTypeId)
        {
            return _context.Products
                .Where(p => p.SkinTypeId == skinTypeId && p.IsDeleted == false)
                .ToList();
        }
        public Product GetProductById(int productId)
        {
            return _context.Products
                .FirstOrDefault(p => p.ProductId == productId && p.IsDeleted == false);
        }
    }
}