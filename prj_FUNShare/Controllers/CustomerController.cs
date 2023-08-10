using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_FUNShare.Models;
using System.Globalization;
using System.Security.Cryptography;

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
        public IActionResult PocketList()
        {
            var datas = from p in _context.Product.Where(p => p.PocketList.FirstOrDefault().MemberId == _id)
                                .Include(p=>p.Status)
                                .Include(p => p.ProductDetail)
                                .ThenInclude(pp=>pp.OrderDetail)
                                .Include(p => p.Supplier)
                                .Include(p=>p.ImageList)
                                .Include(p => p.ProductCategories)
                                .ThenInclude(pp=>pp.SubCategory)
                                .ThenInclude(pp=>pp.Category)
                        select p;
            return View(datas);
        }
        public  IActionResult myOrder()
        {
            var datas = from o in _context.Order.Where(p => p.MemberId == _id)
                        .Include(p => p.OrderDetail)
                        .ThenInclude(pp => pp.ProductDetail)
                        .ThenInclude(ppp => ppp.Product)
                        .ThenInclude(pppp => pppp.Supplier)

                         .Include(p => p.OrderDetail)
                        .ThenInclude(pp=>pp.Status)

                        .Include(p => p.Status)
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
        public IActionResult AccountEdit(int? id=8)
        {
            var datas = from c in _context.CustomerInfomation.Where(p=>p.MemberId==id)
                select c;
            CustomerInfomation member = datas.FirstOrDefault();
                        
            return View(member);
        }
    }
}
