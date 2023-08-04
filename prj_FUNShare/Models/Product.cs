using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? ClassId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductIntro { get; set; }

    public int SupplierId { get; set; }

    public int? AgeId { get; set; }

    public int? Level { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Stock { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime? ReleasedTime { get; set; }

    public int? Times { get; set; }

    public string? Interval { get; set; }

    public string? Note { get; set; }

    public int StatusId { get; set; }

    public bool IsClass { get; set; }

    public double? Commision { get; set; }

    public virtual ICollection<AchievementList> AchievementLists { get; set; } = new List<AchievementList>();

    public virtual ICollection<AdvertiseProductDetail> AdvertiseProductDetails { get; set; } = new List<AdvertiseProductDetail>();

    public virtual Age? Age { get; set; }

    public virtual Product? Class { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ImageList> ImageLists { get; set; } = new List<ImageList>();

    public virtual ICollection<Product> InverseClass { get; set; } = new List<Product>();

    public virtual ICollection<PocketList> PocketLists { get; set; } = new List<PocketList>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
