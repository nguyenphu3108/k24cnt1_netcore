using Microsoft.AspNetCore.Mvc;

namespace TvcLessionMVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
