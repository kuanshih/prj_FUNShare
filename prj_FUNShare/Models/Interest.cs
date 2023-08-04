using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Interest
{
    public int InterestId { get; set; }

    public int SubCategoryId { get; set; }

    public int MemberId { get; set; }

    public virtual CustomerInfomation Member { get; set; } = null!;

    public virtual SubCategory SubCategory { get; set; } = null!;
}
