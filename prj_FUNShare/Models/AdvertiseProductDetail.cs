﻿using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class AdvertiseProductDetail
{
    public int PackageDetailId { get; set; }

    public int PackageId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public DateTime BeginTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime OrderTime { get; set; }

    public int? ProductId { get; set; }

    public virtual AdvertiseProduct Package { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
