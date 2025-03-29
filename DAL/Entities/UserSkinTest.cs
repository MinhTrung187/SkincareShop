using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class UserSkinTest
{
    public int TestId { get; set; }

    public int? UserId { get; set; }

    public int? SkinTypeId { get; set; }

    public DateTime? TestDate { get; set; }

    public virtual SkinType? SkinType { get; set; }

    public virtual User? User { get; set; }
}
