using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionName { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
