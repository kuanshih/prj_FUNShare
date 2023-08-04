using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string? Description { get; set; }

    public string? StatusType { get; set; }

    public virtual ICollection<CustomerInfomation> CustomerInfomations { get; set; } = new List<CustomerInfomation>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
