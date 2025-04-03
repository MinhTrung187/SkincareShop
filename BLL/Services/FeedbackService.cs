﻿using DAL.Entities;
using SkincareShop.Repositories;
using System.Collections.Generic;

namespace SkincareShop.Services
{
    public class FeedbackService
    {
        private readonly FeedbackRepository _repository;

        public FeedbackService()
        {
            _repository = new FeedbackRepository();
        }

        public List<Feedback> GetFeedbacksByProductId(int productId)
        {
            return _repository.GetFeedbacksByProductId(productId);
        }
    }
}