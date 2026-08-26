using Microsoft.AspNetCore.Mvc;
using Tvclesson2.Models;

namespace Tvclesson2.Controllers
{
    public class TcvProductController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.name = "Nguyễn Phú";
            ViewData["address"] = "Fit NTU ";
            TempData["UNI"] = "Trường Đại Học Nguyễn Trãi";

            return View();
        }

        public IActionResult GetProduct()
        {
            
             TcvProduct tvcProduct = new TcvProduct()
            {
                ProductId = "P001",
                ProductName = "Laptop Dell Vostro",
                YearRelease = 2024,
                Price = 12000000,
            };

            ViewData["productVD"] = tvcProduct;
            ViewBag.productVB = tvcProduct;

            return View();
        }
    }
}
