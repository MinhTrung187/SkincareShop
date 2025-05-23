﻿using DAL;
using DAL.Entities;
using DAL.Repositories;
using SkincareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public IEnumerable<Order> GetAllOrdersWithDetails()
        {
            return _orderRepository.GetAllOrdersWithDetails();
        }


        public List<OrderHistoryItem> GetOrderHistory(int userId)
        {
            return _orderRepository.GetOrderHistoryByUserId(userId);
        }
        public List<Order> GetOrderByUserId(int userId)
        {
            return _orderRepository.GetOrderByUserId(userId);
        }
        public bool PlaceOrder(int userId, int productId, int quantity)
        {
            using (var context = new SkincareShopContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int stock = _orderRepository.GetProductStock(productId);
                    if (stock < quantity)
                    {
                        throw new Exception($"Sản phẩm không đủ hàng! Chỉ còn {stock} sản phẩm.");
                    }

                    if (quantity <= 0)
                    {
                        throw new Exception("Số lượng phải lớn hơn 0!");
                    }

                    decimal price = _orderRepository.GetProductPrice(productId);
                    if (price == 0)
                    {
                        throw new Exception("Không tìm thấy sản phẩm!");
                    }

                    decimal totalAmount = price * quantity;

                    int orderId = _orderRepository.CreateOrder(userId, totalAmount);

                    _orderRepository.CreateOrderDetail(orderId, productId, quantity, price);

                    _orderRepository.UpdateProductStock(productId, quantity);

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi đặt hàng: " + ex.Message);
                }


            }


        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _orderRepository.GetOrdersByUserId(userId);
        }
    }
}

        
    
    

