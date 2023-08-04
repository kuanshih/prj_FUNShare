using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Age
{
    public int AgeId { get; set; }

    public string? Grade { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
