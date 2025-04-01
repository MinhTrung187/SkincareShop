using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkincareShop.ProductWindow
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }

        public ProductDetailViewModel(Product product)
        {
            Product = product;
        }

        public string Name => Product.Name;
        public string? ImageUrl => Product.ImageUrl;
        public string? Description => Product.Description;
        public decimal Price => Product.Price;
        public int Stock => Product.Stock;
        public string? SkinTypeName => Product.SkinType?.Name;
    }
}
