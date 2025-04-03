using DAL.Entities;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace SkincareShop.Repositories
{
    public class SkinTypeTestRepository
    {
        private readonly SkincareShopContext _context;

        public SkinTypeTestRepository()
        {
            _context = new SkincareShopContext();
        }

        public List<TestQuestion> GetAllQuestions()
        {
            return _context.TestQuestions.ToList();
        }

        public List<TestAnswer> GetAnswersForQuestion(int questionId)
        {
            return _context.TestAnswers
                .Where(a => a.QuestionId == questionId)
                .ToList();
        }

        public string GetSkinTypeName(int skinTypeId)
        {
            return _context.SkinTypes
                .Where(st => st.SkinTypeId == skinTypeId)
                .Select(st => st.Name)
                .FirstOrDefault() ?? "Không xác định";
        }
    }
}