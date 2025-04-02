using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
    public string Name { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description length can't be more than 500.")]
    public string? Description { get; set; }

    [Range(0, 900000000, ErrorMessage = "Price must be between 0 and 900000000")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative number.")]
    public int Stock { get; set; }

    public int? SkinTypeId { get; set; }

    [Url(ErrorMessage = "Invalid URL format.")]
    public string? ImageUrl { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual SkinType? SkinType { get; set; }
}
