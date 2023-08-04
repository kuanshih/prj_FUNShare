using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderTime { get; set; }

    public int MemberId { get; set; }

    public string? TaxId { get; set; }

    public int StatusId { get; set; }

    public virtual CustomerInfomation Member { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Status Status { get; set; } = null!;
}
