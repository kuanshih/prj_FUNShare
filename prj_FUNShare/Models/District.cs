using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class District
{
    public int DistrictId { get; set; }

    public string DistrictName { get; set; } = null!;

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<CustomerInfomation> CustomerInfomations { get; set; } = new List<CustomerInfomation>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
