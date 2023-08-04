using Microsoft.AspNetCore.Mvc;

namespace prj_FUNShare.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
