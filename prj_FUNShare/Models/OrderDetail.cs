using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductDetailId { get; set; }

    public int MemberId { get; set; }

    public int StatusId { get; set; }

    public int? Grade { get; set; }

    public virtual CustomerInfomation Member { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ProductDetail ProductDetail { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
