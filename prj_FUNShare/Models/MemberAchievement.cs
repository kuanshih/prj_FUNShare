﻿using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class MemberAchievement
{
    public int MemberAchievementId { get; set; }

    public int MemberId { get; set; }

    public int AchievementId { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual CustomerInfomation Member { get; set; } = null!;
}
