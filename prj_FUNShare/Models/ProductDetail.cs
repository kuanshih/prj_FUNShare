using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class ProductDetail
{
    public int ProductDetailId { get; set; }

    public int ProductId { get; set; }

    public DateTime? BeginTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? DistrictId { get; set; }

    public int StatusId { get; set; }

    public string? Address { get; set; }

    public virtual District? District { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product Product { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
