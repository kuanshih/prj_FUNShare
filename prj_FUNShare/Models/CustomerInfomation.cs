using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class CustomerInfomation
{
    public int MemberId { get; set; }

    public string ResidentId { get; set; } = null!;

    public int? ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public int? DisctrictId { get; set; }

    public string? Address { get; set; }

    public DateTime BirthDate { get; set; }

    public string? Nickname { get; set; }

    public string Password { get; set; } = null!;

    public bool IsAllergy { get; set; }

    public string? AllergyDescription { get; set; }

    public string? Note { get; set; }

    public int StatusId { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual District? Disctrict { get; set; }

    public virtual ICollection<Interest> Interests { get; set; } = new List<Interest>();

    public virtual ICollection<CustomerInfomation> InverseParent { get; set; } = new List<CustomerInfomation>();

    public virtual ICollection<MemberAchievement> MemberAchievements { get; set; } = new List<MemberAchievement>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual CustomerInfomation? Parent { get; set; }

    public virtual ICollection<PocketList> PocketLists { get; set; } = new List<PocketList>();

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
