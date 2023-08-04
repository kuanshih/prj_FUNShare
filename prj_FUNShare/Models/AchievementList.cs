using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class AchievementList
{
    public int AchievementListId { get; set; }

    public int ProductId { get; set; }

    public int AchievementId { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
