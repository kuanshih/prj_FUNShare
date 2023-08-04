using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Achievement
{
    public int AchievementId { get; set; }

    public string AchievementName { get; set; } = null!;

    public string? AchievementDescription { get; set; }

    public virtual ICollection<AchievementList> AchievementLists { get; set; } = new List<AchievementList>();

    public virtual ICollection<MemberAchievement> MemberAchievements { get; set; } = new List<MemberAchievement>();
}
