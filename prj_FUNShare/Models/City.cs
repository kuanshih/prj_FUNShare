﻿using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public int? RegionId { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual Region? Region { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
