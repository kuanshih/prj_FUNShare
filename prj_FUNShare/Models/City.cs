﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; }

    public int? RegionId { get; set; }

    public virtual ICollection<District> District { get; set; } = new List<District>();

    public virtual Region Region { get; set; }

    public virtual ICollection<Supplier> Supplier { get; set; } = new List<Supplier>();
}