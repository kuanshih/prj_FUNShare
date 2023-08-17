using prj_FUNShare.Models;
using System.ComponentModel;

namespace prjFunShare_Core.ViewModels
{
    public class CProductCardViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Features { get; set; }
        public string? AgeGrade { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string? CityName { get; set; }
        public double? Rank { get; set; }
        public string? ImagePath { get; set; }
        public string IsClass { get; set; }
        public bool IsPocketed { get; set; }
        public decimal _UnitPrice;
        public string UnitPrice
        {
            get
            {
                return _UnitPrice.ToString("###,###");
            }
            set
            {
                _UnitPrice = decimal.Parse(value);
            }
        }
        public string? SubCategoryName { get; set; }
        public int orderCount { get; set; }

    }
}
