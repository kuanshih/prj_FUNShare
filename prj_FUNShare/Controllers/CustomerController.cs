using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_FUNShare.Models;

namespace prj_FUNShare.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult PocketList(int? id)
        {
            FUNShareContext db = new FUNShareContext();
            IEnumerable<Product> datas = db.Product.Where(p => p.PocketList.FirstOrDefault().MemberId ==id);
            return View(datas);
        }
        public IActionResult myOrder(int? id)
        {
            return View();
        }
        public IActionResult myCoupon()
        {
            return View();
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
