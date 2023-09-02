using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_FUNShare.Models;
using prj_FUNShare.ViewModels;
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
                                //.Include(p=>p.Status)
                                .Include(p => p.ProductDetail)
                                .ThenInclude(pp=>pp.OrderDetail)
                                .Include(p => p.Supplier)
                                .Include(p=>p.ImageList)
                                .Include(p => p.ProductCategories)
                                .ThenInclude(pp=>pp.SubCategory)
                                .ThenInclude(ppp=>ppp.Category)
                                .Include(p=>p.ProductDetail)
                                .ThenInclude(pp=>pp.District)
                                .ThenInclude(ppp=>ppp.City)
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
                        .ThenInclude(pp => pp.Status)

                        .Include(p => p.Status)
                        .Include(p => p.OrderDetail)
                        .ThenInclude(pp => pp.ProductDetail)
                        .ThenInclude(ppp => ppp.Product)
                        .ThenInclude(pppp => pppp.ImageList)
                        orderby o.OrderDetail.First().ProductDetail.BeginTime descending
                        select o;
            return View(datas);

        }

        public IActionResult myOrderDetail(myOrderDetailViewModel vm)
        {
            return View();
        }

   

        public IActionResult myCoupon()
        {
            var datas = from i in _context.CouponList
                        .Include(p=>p.Order)
                        .ThenInclude(p => p.OrderDetail)
                        .ThenInclude(pp => pp.ProductDetail)
                        .ThenInclude(ppp => ppp.Product)
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
        public async Task <IActionResult> products()
        {
            return _context.Product != null ?
                View(await _context.Product.ToListAsync()) :
                          Problem("Entity set 'DemoContext.Product'  is null.");
        }
        public async Task<IActionResult> asyncTest()
        {
            var datas = from p in _context.Product.Where(p => p.PocketList.FirstOrDefault().MemberId == _id)
                                   .Include(p => p.ProductDetail)
                                       .ThenInclude(pp => pp.OrderDetail)
                                                         .Include(p => p.Supplier)
                                                                        .Include(p => p.ProductCategories)
                                .ThenInclude(pp => pp.SubCategory)
        

                        select p;
            return datas != null ?
                View(await datas.ToListAsync()) :
                Problem("Entity set 'DemoContext.Product'  is null.");



        }

        public IActionResult myCalendar()
        {
            return View();
        }

        public IActionResult asyncmyOrderDetail(int? orderId)
        {
            return View();
        }
        public IActionResult reccommend()
        {
            return PartialView();
        }

        public IActionResult testing()
        {
            return View();
        }

        public IActionResult createComment() 
        {
            return View();
        }
        public IActionResult chatbox() {
            {
                return View();
            } 
        }
        public IActionResult google_calendar()
        {
            {
                return View();
            }
        }
    }
}
