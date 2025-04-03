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
                .Include(f => f.User) 
                .Where(f => f.ProductId == productId)
                .OrderByDescending(f => f.CreatedAt)
                .ToList();
        }

        public void AddFeedback(int userId, int productId, int rating, string comment)
        {
            using var context = new SkincareShopContext();
            var feedback = new Feedback
            {
                UserId = userId,
                ProductId = productId,
                Rating = rating,
                Comment = comment,
                CreatedAt = DateTime.Now
            };
            context.Feedbacks.Add(feedback);
            context.SaveChanges();
        }
    }
}