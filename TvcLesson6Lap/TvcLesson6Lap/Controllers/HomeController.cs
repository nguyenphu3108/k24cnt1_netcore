using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TvcLesson6Lap.Models;

namespace TvcLesson6Lap.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "36 Booster pack Pitch Black", ImageUrl = "/images/1.jpg" },
                new Product { Id = 2, Name = "36 Booster pack Chaos Rising", ImageUrl = "/images/2.jpg" },
                new Product { Id = 3, Name = "36 Booster pack Perfect Order", ImageUrl = "/images/3.jpg" }
            };
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
