using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int ProductId { get; set; }

    public int MemberId { get; set; }

    public string? Review { get; set; }

    public double? Rank { get; set; }

    public DateTime? Date { get; set; }

    public virtual CustomerInfomation Member { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
