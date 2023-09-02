using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using prj_FUNShare.Models;
using prj_FUNShare.ViewModels;
using prjFunShare_Core.ViewModels;

namespace prj_FUNShare.Controllers
{
    public class apiController : Controller
    {
        private readonly FUNShareContext _context;
        private readonly IWebHostEnvironment _host;
        private readonly int _id;
        public apiController(FUNShareContext context, IWebHostEnvironment host, int memberId = 8)
        {
            _context = context;
            _id = memberId;
            _host = host;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PocketCardItem()
        {

            int id = 8; //todo 先寫死
            //----------------------------------------------------登入//

            //----------------------------------------------------登入//

            //----------------------------------------------------卡片資料//
            var datas = from prod in _context.Product
                        where prod.StatusId == 12 && prod.PocketList.FirstOrDefault().MemberId == id
                        select new CProductCardViewModel
                        {
                            ProductId = prod.ProductId,
                            ProductName = prod.ProductName,
                            Features = string.IsNullOrEmpty(prod.Features) ? prod.ProductIntro : prod.Features,
                            //AgeGrade = prod.Age.Grade,
                            CategoryId = prod.ProductCategories.First().SubCategory.CategoryId,
                            CategoryName = prod.ProductCategories.First().SubCategory.Category.CategoryName,
                            SubCategoryName = prod.ProductCategories.First().SubCategory.SubCategoryName,
                            CityName = prod.ProductDetail.Select(x => x.District.City.CityName).Distinct().Count() > 1 ? "多縣市" : prod.ProductDetail.Select(x => x.District.City.CityName).First(),
                            //Rank = prod.Comment.Select(x => x.Rank).Average(),
                            ImagePath = prod.ImageList.Where(x => x.IsMain == true).First().ImagePath,
                            IsClass = prod.IsClass ? "課程" : "體驗",
                            IsPocketed = prod.PocketList.Where(x => x.MemberId == id).Any(),
                            _UnitPrice = (int)prod.ProductDetail.Select(x => x.UnitPrice).Min()
                        };
                        return Json(datas);
        }

        //待刪除 改用getmyOrderDetail
        public IActionResult getOrderDetail()
        {
            int id = 8; //todo 先寫死
            var datas = from order in _context.Order
                        .Include(x => x.OrderDetail)
                        .ThenInclude(x=>x.ProductDetail)
                        where order != null && order.MemberId == id
                        orderby order.OrderDetail.First().ProductDetail.BeginTime descending

                        select new COrderItmeVIewModel
                        {
                            //ProductId = 8,
                            orderId = order.OrderId,
                            ProductId = order.OrderDetail.First().ProductDetail.ProductId,
                            ProductName = order.OrderDetail.First().ProductDetail.Product.ProductName,
                            Features = string.IsNullOrEmpty(order.OrderDetail.First().ProductDetail.Product.Features)? order.OrderDetail.First().ProductDetail.Product.ProductIntro: order.OrderDetail.First().ProductDetail.Product.Features,
                            CategoryId = order.OrderDetail.First().ProductDetail.Product.ProductCategories.First().SubCategory.CategoryId,
                            CategoryName = order.OrderDetail.First().ProductDetail.Product.ProductCategories.First().SubCategory.Category.CategoryName,
                            CityName = order.OrderDetail.First().ProductDetail.District.City.CityName,
                            SupplierName = order.OrderDetail.First().ProductDetail.Product.Supplier.SupplierName,
                            beginTime = order.OrderDetail.First().ProductDetail.BeginTime,
                            endTime = order.OrderDetail.First().ProductDetail.EndTime,
                            _UnitPrice = (int)order.OrderDetail.First().ProductDetail.UnitPrice,
                            OrderStatus = order.Status.Description,
                            OrderDetailStatus = order.OrderDetail.First().Status.Description,
                            ImagePath = order.OrderDetail.First().ProductDetail.Product.ImageList.First().ImagePath,
                        };
                        return Json(datas);
        }
        public IActionResult getmyOrderDetail(int? orderId)
        {
            int memberId = 8; //todo 先寫死
           
            var query = _context.Order
        .Include(x => x.OrderDetail)
            .ThenInclude(x => x.ProductDetail)
        .Where(order => order != null && order.MemberId == memberId);
            if (orderId.HasValue)
            {
                query = query.Where(order => order.OrderId == orderId);
                
            }


            var datas = query
                    .OrderByDescending(order => order.OrderDetail.First().ProductDetail.BeginTime)
        .Select(order => new COrderItmeVIewModel
        {
            //ProductId = 8,
            MemberId = memberId,
            orderId = order.OrderId,
            ProductId = order.OrderDetail.First().ProductDetail.ProductId,
            ProductName = order.OrderDetail.First().ProductDetail.Product.ProductName,
            Features = string.IsNullOrEmpty(order.OrderDetail.First().ProductDetail.Product.Features) ? order.OrderDetail.First().ProductDetail.Product.ProductIntro : order.OrderDetail.First().ProductDetail.Product.Features,
            CategoryId = order.OrderDetail.First().ProductDetail.Product.ProductCategories.First().SubCategory.CategoryId,
            CategoryName = order.OrderDetail.First().ProductDetail.Product.ProductCategories.First().SubCategory.Category.CategoryName,
            CityName = order.OrderDetail.First().ProductDetail.District.City.CityName,
            SupplierName = order.OrderDetail.First().ProductDetail.Product.Supplier.SupplierName,
            OrderTime = order.OrderTime,
            beginTime = order.OrderDetail.First().ProductDetail.BeginTime,
            endTime = order.OrderDetail.First().ProductDetail.EndTime,
            _UnitPrice = (int)order.OrderDetail.First().ProductDetail.UnitPrice,
            OrderStatus = order.Status.Description,
            OrderDetailStatus = order.OrderDetail.First().Status.Description,
            ImagePath = order.OrderDetail.First().ProductDetail.Product.ImageList.First().ImagePath,
            Address = order.OrderDetail.FirstOrDefault().ProductDetail.Address,
            districtName = order.OrderDetail.First().ProductDetail.District.DistrictName,
            isAttend = order.OrderDetail.First().IsAttend,
            count =order.Count
            
        }) ;
            return Json(datas);


        }

        public IActionResult now()
        {
            // Get current server time
            DateTime currentTime = DateTime.Now;

            // Return current time as JSON
            return Json(new { currentTime = currentTime });

        }
        public IActionResult recommend()
        {
            int id = 8; //todo 先寫死
            //----------------------------------------------------登入//

            //----------------------------------------------------登入//

            //----------------------------------------------------卡片資料//
            var datas = from prod in _context.Product
                        where prod.StatusId == 12 && prod.PocketList.FirstOrDefault().MemberId == id
                        select new CProductCardViewModel
                        {
                            ProductId = prod.ProductId,
                            ProductName = prod.ProductName,
                            Features = string.IsNullOrEmpty(prod.Features) ? prod.ProductIntro : prod.Features,
                            //AgeGrade = prod.Age.Grade,
                            CategoryId = prod.ProductCategories.First().SubCategory.CategoryId,
                            CategoryName = prod.ProductCategories.First().SubCategory.Category.CategoryName,
                            SubCategoryName = prod.ProductCategories.First().SubCategory.SubCategoryName,
                            CityName = prod.ProductDetail.Select(x => x.District.City.CityName).Distinct().Count() > 1 ? "多縣市" : prod.ProductDetail.Select(x => x.District.City.CityName).First(),
                            //Rank = prod.Comment.Select(x => x.Rank).Average(),
                            ImagePath = prod.ImageList.Where(x => x.IsMain == true).First().ImagePath,
                            IsClass = prod.IsClass ? "課程" : "體驗",
                            IsPocketed = prod.PocketList.Where(x => x.MemberId == id).Any(),
                            _UnitPrice = (int)prod.ProductDetail.Select(x => x.UnitPrice).Min()
                        };
            return Json(datas);
        }
        public IActionResult getCourses(int? id, DateTime date)
        {
            id = 8; //todo 先寫死
            var datas = from order in _context.Order
                        .Include(x => x.OrderDetail)
                        .ThenInclude(x => x.ProductDetail)
                        where order != null && order.MemberId == id /*&& order.OrderDetail.First().ProductDetail.BeginTime >= date && order.OrderDetail.First().ProductDetail.EndTime <= date*/
                        orderby order.OrderDetail.First().ProductDetail.BeginTime descending

                        select new CMyScheduleViewModel
                        {
                            //ProductId = 8,
                            orderId = order.OrderId,
                            ProductName = order.OrderDetail.First().ProductDetail.Product.ProductName,
                            Feature = order.OrderDetail.First().ProductDetail.Product.Features,
                            beginTime = order.OrderDetail.First().ProductDetail.BeginTime,
                            endTime = order.OrderDetail.First().ProductDetail.EndTime,
                            OrderStatus = order.Status.Description,
                        };
            return Json(datas);
        }

        public IActionResult getschedule(int? id)
        {
            id = 8; //todo 先寫死
            var datas = from order in _context.Order
                        .Include(x => x.OrderDetail)
                        .ThenInclude(x => x.ProductDetail)
                        where order != null && order.MemberId == id/* && order.OrderDetail.First().ProductDetail.BeginTime >= date && order.OrderDetail.First().ProductDetail.EndTime <= date*/
                        orderby order.OrderDetail.First().ProductDetail.BeginTime descending

                        select new CMyScheduleViewModel
                        {
                            //ProductId = 8,
                            orderId = order.OrderId,
                            ProductName = order.OrderDetail.First().ProductDetail.Product.ProductName,
                            beginTime = order.OrderDetail.First().ProductDetail.BeginTime,
                            endTime = order.OrderDetail.First().ProductDetail.EndTime,
                            OrderStatus = order.Status.Description,
                        };
            return Json(datas);
        }

        public IActionResult createComment(Comment comment, IFormFile file)
        {
            
            //存入實體路徑
            string photoName = Guid.NewGuid().ToString() + ".jpg";  //產生不重複檔名
            string filepath = Path.Combine(_host.WebRootPath, "img/commentImg", photoName);
            using (var filestream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(filestream);
            }
            comment.ImagePath = photoName;
            _context.Comment.Add(comment);
            _context.SaveChanges();
            return Content("新增成功");
        }
    }
}
