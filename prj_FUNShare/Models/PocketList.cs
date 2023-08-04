using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class PocketList
{
    public int PocketlistId { get; set; }

    public int ProductId { get; set; }

    public int MemberId { get; set; }

    public virtual CustomerInfomation Member { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
