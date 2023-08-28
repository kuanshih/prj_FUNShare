﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prj_FUNShare.Models;

public partial class CustomerInfomation
{
    public int MemberId { get; set; }

    public string ResidentId { get; set; }

    public int? ParentId { get; set; }

    public string Name { get; set; }

    public string Gender { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public int? DistrictId { get; set; }

    public string Address { get; set; }

    public DateTime? BirthDate { get; set; }

    public string Nickname { get; set; }

    public string Password { get; set; }

    public bool? IsAllergy { get; set; }

    public string AllergyDescription { get; set; }

    public string Note { get; set; }

    public int? StatusId { get; set; }

    public byte[] Photo { get; set; }

    public DateTime? RegistrationDay { get; set; }

    public string SuspensionReason { get; set; }

    public virtual ICollection<Bonus> Bonus { get; set; } = new List<Bonus>();

    public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();

    public virtual District District { get; set; }

    public virtual ICollection<Interest> Interest { get; set; } = new List<Interest>();

    public virtual ICollection<CustomerInfomation> InverseParent { get; set; } = new List<CustomerInfomation>();

    public virtual ICollection<MemberAchievement> MemberAchievement { get; set; } = new List<MemberAchievement>();

    public virtual ICollection<MemberCoupon> MemberCoupon { get; set; } = new List<MemberCoupon>();

    public virtual ICollection<Order> Order { get; set; } = new List<Order>();

    public virtual ICollection<OrderDetail> OrderDetail { get; set; } = new List<OrderDetail>();

    public virtual CustomerInfomation Parent { get; set; }

    public virtual ICollection<PocketList> PocketList { get; set; } = new List<PocketList>();

    public virtual Status Status { get; set; }

    public virtual ICollection<Survey> Survey { get; set; } = new List<Survey>();
}