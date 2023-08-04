using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class Survey
{
    public int SurveyId { get; set; }

    public int OrderDetailId { get; set; }

    public int MemberId { get; set; }

    public int? GeneralRank { get; set; }

    public string? GeneralSuggestion { get; set; }

    public int? EnvironmentRank { get; set; }

    public string? EnvironmentSuggestion { get; set; }

    public int TeacherRank { get; set; }

    public string? TeacherSuggestion { get; set; }

    public string? Others { get; set; }

    public virtual CustomerInfomation Member { get; set; } = null!;

    public virtual OrderDetail OrderDetail { get; set; } = null!;
}
