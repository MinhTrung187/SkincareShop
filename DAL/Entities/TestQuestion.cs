using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TestQuestion
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = null!;

    public virtual ICollection<TestAnswer> TestAnswers { get; set; } = new List<TestAnswer>();
}
