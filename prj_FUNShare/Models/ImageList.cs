using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class ImageList
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public byte[]? Images { get; set; }

    public virtual Product Product { get; set; } = null!;
}
