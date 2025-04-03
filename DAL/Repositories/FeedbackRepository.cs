using DAL.Entities;
using DAL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SkincareShop.Repositories
{
    public class FeedbackRepository
    {
        private readonly SkincareShopContext _context;

        public FeedbackRepository()
        {
            _context = new SkincareShopContext();
        }

        public List<Feedback> GetFeedbacksByProductId(int productId)
        {
            return _context.Feedbacks
                .Where(f => f.ProductId == productId)
                .OrderByDescending(f => f.CreatedAt)
                .ToList();
        }
    }
}