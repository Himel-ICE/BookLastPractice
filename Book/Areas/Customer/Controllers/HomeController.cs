using Microsoft.AspNetCore.Mvc;

namespace Book.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
