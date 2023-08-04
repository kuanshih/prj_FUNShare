using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class AdvertiseProduct
{
    public int PackageId { get; set; }

    public string PackageName { get; set; } = null!;

    public string? AdsDescription { get; set; }

    public virtual ICollection<AdvertiseOrder> AdvertiseOrders { get; set; } = new List<AdvertiseOrder>();

    public virtual ICollection<AdvertiseProductDetail> AdvertiseProductDetails { get; set; } = new List<AdvertiseProductDetail>();
}
