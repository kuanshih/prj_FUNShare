using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prj_FUNShare.Models;

public partial class FunshareContext : DbContext
{
    public FunshareContext()
    {
    }

    public FunshareContext(DbContextOptions<FunshareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<AchievementList> AchievementLists { get; set; }

    public virtual DbSet<AdvertiseOrder> AdvertiseOrders { get; set; }

    public virtual DbSet<AdvertiseProduct> AdvertiseProducts { get; set; }

    public virtual DbSet<AdvertiseProductDetail> AdvertiseProductDetails { get; set; }

    public virtual DbSet<Age> Ages { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CustomerInfomation> CustomerInfomations { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<ImageList> ImageLists { get; set; }

    public virtual DbSet<Interest> Interests { get; set; }

    public virtual DbSet<MemberAchievement> MemberAchievements { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PocketList> PocketLists { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FUNShare;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId)
                .ValueGeneratedNever()
                .HasColumnName("Achievement_ID");
            entity.Property(e => e.AchievementDescription)
                .HasMaxLength(50)
                .HasColumnName("Achievement_Description");
            entity.Property(e => e.AchievementName)
                .HasMaxLength(10)
                .HasColumnName("Achievement_Name");
        });

        modelBuilder.Entity<AchievementList>(entity =>
        {
            entity.ToTable("AchievementList");

            entity.Property(e => e.AchievementListId)
                .ValueGeneratedNever()
                .HasColumnName("AchievementList_ID");
            entity.Property(e => e.AchievementId).HasColumnName("Achievement_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Achievement).WithMany(p => p.AchievementLists)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AchievementList_Achievement");

            entity.HasOne(d => d.Product).WithMany(p => p.AchievementLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AchievementList_Product");
        });

        modelBuilder.Entity<AdvertiseOrder>(entity =>
        {
            entity.HasKey(e => e.AdOrderId);

            entity.ToTable("Advertise_Order");

            entity.Property(e => e.AdOrderId).HasColumnName("Ad_Order_ID");
            entity.Property(e => e.PackageId).HasColumnName("Package_ID");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

            entity.HasOne(d => d.Package).WithMany(p => p.AdvertiseOrders)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Advertise_Order_Advertise_Product");

            entity.HasOne(d => d.Supplier).WithMany(p => p.AdvertiseOrders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Advertise_Order_Supplier");
        });

        modelBuilder.Entity<AdvertiseProduct>(entity =>
        {
            entity.HasKey(e => e.PackageId);

            entity.ToTable("Advertise_Product");

            entity.Property(e => e.PackageId).HasColumnName("Package_ID");
            entity.Property(e => e.AdsDescription)
                .HasColumnType("ntext")
                .HasColumnName("Ads_Description");
            entity.Property(e => e.PackageName)
                .HasMaxLength(50)
                .HasColumnName("Package_Name");
        });

        modelBuilder.Entity<AdvertiseProductDetail>(entity =>
        {
            entity.HasKey(e => e.PackageDetailId);

            entity.ToTable("Advertise_Product_Detail");

            entity.Property(e => e.PackageDetailId).HasColumnName("Package_Detail_ID");
            entity.Property(e => e.BeginTime)
                .HasColumnType("date")
                .HasColumnName("Begin_Time");
            entity.Property(e => e.EndTime)
                .HasColumnType("date")
                .HasColumnName("End_Time");
            entity.Property(e => e.OrderTime)
                .HasColumnType("datetime")
                .HasColumnName("Order_Time");
            entity.Property(e => e.PackageId).HasColumnName("Package_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasColumnName("Unit_Price");

            entity.HasOne(d => d.Package).WithMany(p => p.AdvertiseProductDetails)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Advertise_Product_Detail_Advertise_Product");

            entity.HasOne(d => d.Product).WithMany(p => p.AdvertiseProductDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Advertise_Product_Detail_Product");
        });

        modelBuilder.Entity<Age>(entity =>
        {
            entity.ToTable("Age");

            entity.Property(e => e.AgeId)
                .ValueGeneratedNever()
                .HasColumnName("Age_ID");
            entity.Property(e => e.Grade).HasMaxLength(20);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(50)
                .HasColumnName("Category_Description");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(30)
                .HasColumnName("Category_Name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("City_ID");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .HasColumnName("City_Name");
            entity.Property(e => e.RegionId).HasColumnName("Region_ID");

            entity.HasOne(d => d.Region).WithMany(p => p.Cities)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_City_Region");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("Comment_ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Member).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Customer_Infomation");

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Product");
        });

        modelBuilder.Entity<CustomerInfomation>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.ToTable("Customer_Infomation");

            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.AllergyDescription).IsUnicode(false);
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("Birth_Date");
            entity.Property(e => e.DisctrictId).HasColumnName("Disctrict_ID");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Gender).HasMaxLength(4);
            entity.Property(e => e.IsAllergy).HasColumnName("IsAllergy?");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Nickname).HasMaxLength(30);
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.ResidentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Resident_ID");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");

            entity.HasOne(d => d.Disctrict).WithMany(p => p.CustomerInfomations)
                .HasForeignKey(d => d.DisctrictId)
                .HasConstraintName("FK_Customer_Infomation_District");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Customer_Infomation_Customer_Infomation");

            entity.HasOne(d => d.Status).WithMany(p => p.CustomerInfomations)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Infomation_Status");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.ToTable("District");

            entity.Property(e => e.DistrictId)
                .ValueGeneratedNever()
                .HasColumnName("District_ID");
            entity.Property(e => e.CityId).HasColumnName("City_ID");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(10)
                .HasColumnName("District_Name");

            entity.HasOne(d => d.City).WithMany(p => p.Districts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_District_City");
        });

        modelBuilder.Entity<ImageList>(entity =>
        {
            entity.HasKey(e => e.ImageId);

            entity.ToTable("Image_List");

            entity.Property(e => e.ImageId).HasColumnName("Image_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Product).WithMany(p => p.ImageLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Image_List_Product");
        });

        modelBuilder.Entity<Interest>(entity =>
        {
            entity.ToTable("Interest");

            entity.Property(e => e.InterestId)
                .ValueGeneratedNever()
                .HasColumnName("Interest_ID");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_ID");

            entity.HasOne(d => d.Member).WithMany(p => p.Interests)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interest_Customer_Infomation");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Interests)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interest_SubCategory");
        });

        modelBuilder.Entity<MemberAchievement>(entity =>
        {
            entity.ToTable("MemberAchievement");

            entity.Property(e => e.MemberAchievementId)
                .ValueGeneratedNever()
                .HasColumnName("MemberAchievement_ID");
            entity.Property(e => e.AchievementId).HasColumnName("Achievement_ID");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");

            entity.HasOne(d => d.Achievement).WithMany(p => p.MemberAchievements)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberAchievement_Achievement");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberAchievements)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberAchievement_Customer_Infomation");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.OrderTime)
                .HasColumnType("datetime")
                .HasColumnName("Order_Time");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
            entity.Property(e => e.TaxId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Tax_ID");

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer_Infomation");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Status");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("Order_Detail");

            entity.Property(e => e.OrderDetailId).HasColumnName("Order_Detail_ID");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.ProductDetailId).HasColumnName("Product_Detail_ID");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");

            entity.HasOne(d => d.Member).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Detail_Customer_Infomation");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Detail_Order");

            entity.HasOne(d => d.ProductDetail).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Detail_Product_Detail");

            entity.HasOne(d => d.Status).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Detail_Status");
        });

        modelBuilder.Entity<PocketList>(entity =>
        {
            entity.ToTable("PocketList");

            entity.Property(e => e.PocketlistId)
                .ValueGeneratedNever()
                .HasColumnName("Pocketlist_ID");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Member).WithMany(p => p.PocketLists)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PocketList_Customer_Infomation");

            entity.HasOne(d => d.Product).WithMany(p => p.PocketLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PocketList_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.AgeId).HasColumnName("Age_ID");
            entity.Property(e => e.ClassId).HasColumnName("Class_ID");
            entity.Property(e => e.Deadline).HasColumnType("date");
            entity.Property(e => e.Interval).HasMaxLength(20);
            entity.Property(e => e.IsClass).HasColumnName("IsClass?");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.ProductIntro)
                .HasColumnType("ntext")
                .HasColumnName("Product_Intro");
            entity.Property(e => e.ProductName)
                .HasMaxLength(30)
                .HasColumnName("Product_Name");
            entity.Property(e => e.ReleasedTime).HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Age).WithMany(p => p.Products)
                .HasForeignKey(d => d.AgeId)
                .HasConstraintName("FK_Product_Age");

            entity.HasOne(d => d.Class).WithMany(p => p.InverseClass)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Product_Product");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Supplier");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategory_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_ID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategories_Product");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategories_SubCategory");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.ToTable("Product_Detail");

            entity.Property(e => e.ProductDetailId).HasColumnName("Product_Detail_ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BeginTime)
                .HasColumnType("datetime")
                .HasColumnName("Begin_Time");
            entity.Property(e => e.DistrictId).HasColumnName("District_ID");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("End_Time");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");

            entity.HasOne(d => d.District).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK_Product_Detail_District");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Detail_Product");

            entity.HasOne(d => d.Status).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Detail_Status");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.Property(e => e.RegionId)
                .ValueGeneratedNever()
                .HasColumnName("Region_ID");
            entity.Property(e => e.RegionName)
                .HasMaxLength(10)
                .HasColumnName("Region_Name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
            entity.Property(e => e.Description).HasMaxLength(10);
            entity.Property(e => e.StatusType)
                .HasMaxLength(20)
                .HasColumnName("Status_Type");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.ToTable("SubCategory");

            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.SubCategoryDescription)
                .HasMaxLength(50)
                .HasColumnName("SubCategory_Description");
            entity.Property(e => e.SubCategoryName)
                .HasMaxLength(10)
                .HasColumnName("SubCategory_Name");

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubCategory_Categories");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.CityId).HasColumnName("City_ID");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(30)
                .HasColumnName("Contact_Person");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LogoImage).HasColumnName("Logo_Image");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(30)
                .HasColumnName("Supplier_Name");
            entity.Property(e => e.SupplierPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Supplier_Phone");
            entity.Property(e => e.SupplierPhoto).HasColumnName("Supplier_Photo");
            entity.Property(e => e.TaxId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Tax_ID");

            entity.HasOne(d => d.City).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Supplier_City");

            entity.HasOne(d => d.Status).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Status");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.ToTable("Survey");

            entity.Property(e => e.SurveyId)
                .ValueGeneratedNever()
                .HasColumnName("Survey_ID");
            entity.Property(e => e.EnvironmentRank).HasColumnName("Environment_Rank");
            entity.Property(e => e.EnvironmentSuggestion)
                .HasMaxLength(50)
                .HasColumnName("Environment_Suggestion");
            entity.Property(e => e.GeneralRank).HasColumnName("General_Rank");
            entity.Property(e => e.GeneralSuggestion)
                .HasMaxLength(50)
                .HasColumnName("General_Suggestion");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.OrderDetailId).HasColumnName("Order_Detail_ID");
            entity.Property(e => e.Others).HasMaxLength(50);
            entity.Property(e => e.TeacherRank).HasColumnName("Teacher_Rank");
            entity.Property(e => e.TeacherSuggestion)
                .HasMaxLength(50)
                .HasColumnName("Teacher_Suggestion");

            entity.HasOne(d => d.Member).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Survey_Customer_Infomation");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.OrderDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Survey_Order_Detail");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
