using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository
    {
        private readonly SkincareShopContext _context;

        public OrderRepository()
        {
            _context = new SkincareShopContext();
        }

        public IEnumerable<Order> GetAllOrdersWithDetails()
        {
            return _context.Orders
            .Include(o => o.OrderDetails) 
            .ThenInclude(od => od.Product)
            .Include("User")
            .ToList();
        }
    }
}
