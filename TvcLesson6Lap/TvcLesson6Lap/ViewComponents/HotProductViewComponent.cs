using Microsoft.AspNetCore.Mvc;
using TvcLesson6Lap.Models;
using TvcLesson6Lap.Models;

namespace TvcLesson6Lap.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var hotProducts = new List<Product>
            {
                new Product { Id = 4, Name = "36 Booster pack Journey Together", ImageUrl = "/images/4.jpg" },
                new Product { Id = 5, Name = "36 Booster pack Stellar Crown", ImageUrl = "/images/5.jpg" },
                new Product { Id = 6, Name = "36 Booster pack Paldea Evolved", ImageUrl = "/images/6.jpg" }
            };
            return View(hotProducts);
        }
    }
}