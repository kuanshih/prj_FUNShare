using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string TaxId { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string? SupplierPhone { get; set; }

    public string Email { get; set; } = null!;

    public int? CityId { get; set; }

    public byte[]? SupplierPhoto { get; set; }

    public string? Fax { get; set; }

    public string Password { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;

    public byte[]? LogoImage { get; set; }

    public string? Description { get; set; }

    public int StatusId { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<AdvertiseOrder> AdvertiseOrders { get; set; } = new List<AdvertiseOrder>();

    public virtual City? City { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Status Status { get; set; } = null!;
}
