using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_FUNShare.Models;

namespace prj_FUNShare.Controllers
{
    public class CustomerController : Controller
    {
        private readonly FUNShareContext _context;
        public CustomerController(FUNShareContext context)
        {
            _context = context;
        }
        public IActionResult PocketList(int? id)
        {
            FUNShareContext db = new FUNShareContext();
            IEnumerable<Product> datas = db.Product.Where(p => p.PocketList.FirstOrDefault().MemberId ==id);
            return View(datas);
        }
        public  IActionResult myOrder()
        {

            var datas = _context.Product.Include(p => p.PocketList).Include(p => p.ImageList);
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
