using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class SkinType
{
    public int SkinTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<UserSkinTest> UserSkinTests { get; set; } = new List<UserSkinTest>();
}
