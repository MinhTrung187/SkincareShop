using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class SkinType
{
    public int SkinTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<TestAnswer> TestAnswers { get; set; } = new List<TestAnswer>();
}
