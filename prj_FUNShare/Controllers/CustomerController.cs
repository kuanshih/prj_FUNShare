using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_FUNShare.Models;
using System.Globalization;

namespace prj_FUNShare.Controllers
{
    public class CustomerController : Controller
    {
        private readonly FUNShareContext _context;
        private readonly int _id;
        public CustomerController(FUNShareContext context, int memberId=8)
        {
            _context = context;
            _id = memberId;
        }
        public IActionResult PocketList(int? id)
        {
            FUNShareContext db = new FUNShareContext();
            IEnumerable<Product> datas = db.Product.Where(p => p.PocketList.FirstOrDefault().MemberId ==id);
            return View(datas);
        }
        public  IActionResult myOrder()
        {

            //var datas = from i in _context.Order.Where(p => p.MemberId == _id)
            //            from p in _context.Product.Where(p=>p.ProductDetail.First().OrderDetail.First().MemberId==_id)
            //            select new {p.ProductName, p.ProductIntro, i.OrderDetail.First().Member };
            var datas = from o in _context.Order.Where(p => p.MemberId == _id)
                        .Include(c => c.OrderDetail)
                        .ThenInclude(ca => ca.ProductDetail)
                        .ThenInclude(cak=>cak.Product)
                        .ThenInclude(cake => cake.)
                        select o;
                        return View(datas);
        }
        public IActionResult myCoupon()
        {
            var datas = from i in _context.CouponList
                        select i;
            return View(datas);
        }
        public IActionResult myPoint()
        {
            return View();
        }
        public IActionResult myAccount()
        {
            return View();
        }
    }
}
