using DAL.Entities;
using DAL;
using SkincareShop;
using SkincareShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace SkincareShop.DAL
{
    public class OrderRepository
    {
        private SkincareShopContext _context;



        public int CreateOrder(int userId, decimal totalAmount)
        {
            _context = new SkincareShopContext();
            var order = new Order
            {
                UserId = userId,
                TotalAmount = totalAmount,
                Status = "Pending",
                OrderDate = DateTime.Now
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.OrderId;
        }

        public void CreateOrderDetail(int orderId, int productId, int quantity, decimal price)
        {
            _context = new SkincareShopContext();
            var orderDetail = new OrderDetail
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity,
                Price = price
            };
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }

        public void UpdateProductStock(int productId, int quantity)
        {
            _context = new SkincareShopContext();
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                product.Stock -= quantity;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }

        public int GetProductStock(int productId)
        {
            _context = new SkincareShopContext();
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            return product?.Stock ?? 0;
        }

        public decimal GetProductPrice(int productId)
        {
            _context = new SkincareShopContext();
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            return product?.Price ?? 0;
        }

        public List<OrderHistoryItem> GetOrderHistoryByUserId(int userId)
        {
            var query = from order in _context.Orders
                        join orderDetail in _context.OrderDetails on order.OrderId equals orderDetail.OrderId
                        join product in _context.Products on orderDetail.ProductId equals product.ProductId
                        where order.UserId == userId
                        select new OrderHistoryItem
                        {
                            OrderDate = order.OrderDate ?? DateTime.Now, 
                            ProductName = product.Name,
                            Quantity = orderDetail.Quantity,
                            Price = orderDetail.Price,
                            ImageUrl = product.ImageUrl
                        };

            return query.ToList();
        }

    }
}