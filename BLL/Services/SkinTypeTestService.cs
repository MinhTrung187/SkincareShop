using DAL.Entities;
using SkincareShop.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SkincareShop.Services
{
    public class SkinTypeTestService
    {
        private readonly SkinTypeTestRepository _repository;

        public SkinTypeTestService()
        {
            _repository = new SkinTypeTestRepository();
        }

        public List<TestQuestion> GetAllQuestions()
        {
            return _repository.GetAllQuestions();
        }

        public List<TestAnswer> GetAnswersForQuestion(int questionId)
        {
            return _repository.GetAnswersForQuestion(questionId);
        }

        public string CalculateSkinType(List<int?> selectedSkinTypeIds)
        {
            var skinTypeCounts = selectedSkinTypeIds
                .Where(id => id.HasValue)
                .GroupBy(id => id)
                .Select(g => new { SkinTypeID = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .FirstOrDefault();

            if (skinTypeCounts == null)
            {
                return "Không xác định";
            }

            return _repository.GetSkinTypeName(skinTypeCounts.SkinTypeID.Value);
        }
    }
}