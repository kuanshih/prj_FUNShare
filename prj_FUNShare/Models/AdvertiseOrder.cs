using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class AdvertiseOrder
{
    public int AdOrderId { get; set; }

    public int PackageId { get; set; }

    public int SupplierId { get; set; }

    public virtual AdvertiseProduct Package { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
