using Microsoft.AspNetCore.Mvc;

namespace Lap1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
