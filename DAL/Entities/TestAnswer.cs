using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TestAnswer
{
    public int AnswerId { get; set; }

    public int QuestionId { get; set; }

    public string AnswerText { get; set; } = null!;

    public int? SkinTypeId { get; set; }

    public virtual TestQuestion Question { get; set; } = null!;

    public virtual SkinType? SkinType { get; set; }
}
