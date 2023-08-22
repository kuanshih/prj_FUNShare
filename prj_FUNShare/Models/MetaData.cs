using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace prj_FUNShare.Models
{
    public class ProductMetaData
    {
        public int ProductId { get; set; }

        [DisplayName("產品名稱")]
        public string ProductName { get; set; }

        public string ProductIntro { get; set; }

        public int SupplierId { get; set; }

        public int? AgeId { get; set; }

        public int? Level { get; set; }

        public int? Stock { get; set; }

        public DateTime? ReleasedTime { get; set; }

        public int? Times { get; set; }

        public int? IntervalId { get; set; }

        public string Note { get; set; }

        public int StatusId { get; set; }

        public bool IsClass { get; set; }

        public double? Commision { get; set; }

        public string Features { get; set; }

        public virtual ICollection<AchievementList> AchievementList { get; set; } = new List<AchievementList>();

        public virtual ICollection<AdvertiseProductDetail> AdvertiseProductDetail { get; set; } = new List<AdvertiseProductDetail>();

        public virtual Age Age { get; set; }

        public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();

        public virtual ICollection<ImageList> ImageList { get; set; } = new List<ImageList>();

        public virtual IntervalList Interval { get; set; }

        public virtual ICollection<PocketList> PocketList { get; set; } = new List<PocketList>();

        public virtual ICollection<ProductCategories> ProductCategories { get; set; } = new List<ProductCategories>();

        public virtual ICollection<ProductDetail> ProductDetail { get; set; } = new List<ProductDetail>();

        public virtual Status Status { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
