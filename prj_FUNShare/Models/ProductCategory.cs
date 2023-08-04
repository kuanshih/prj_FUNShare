using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public int ProductId { get; set; }

    public int SubCategoryId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SubCategory SubCategory { get; set; } = null!;
}
