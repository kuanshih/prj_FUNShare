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
            IEnumerable<Product> datas = _context.Product.Where(p => p.PocketList.FirstOrDefault().MemberId ==id);
            return View(datas);
        }
        public  IActionResult myOrder()
        {
            var datas = from o in _context.Order.Where(p => p.MemberId == _id)
                        .Include(c => c.OrderDetail)
                        .ThenInclude(ca => ca.ProductDetail)
                        .ThenInclude(cak => cak.Product)
                        .ThenInclude(cake => cake.Supplier)

                         .Include(c => c.OrderDetail)
                        .ThenInclude(cc=>cc.Status)

                        .Include(cc => cc.Status)
                        orderby o.OrderDetail.First().ProductDetail.BeginTime descending
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
            var datas = from b in _context.Bonus.Where(p =>p.MemberId == _id)
                        select b;
            return View(datas);
        }
        public IActionResult myAccount()
        {
            return View();
        }
    }
}
