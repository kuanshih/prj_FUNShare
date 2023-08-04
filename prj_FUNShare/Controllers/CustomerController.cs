using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_FUNShare.Models;

namespace prj_FUNShare.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult PocketList(int? id)
        {
             FunshareContext db = new FunshareContext();
            IEnumerable<Product> datas = db.Products.Where(p => p.PocketLists.FirstOrDefault().MemberId ==id);
            return View(datas);
        }
        public IActionResult myOrder()
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
