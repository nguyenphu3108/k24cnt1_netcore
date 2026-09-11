using Microsoft.AspNetCore.Mvc;
using TvcLesson6Lap.Models;

namespace TvcLesson06.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "36 Booster Pack Box"},
                new Category { CategoryId = 2, CategoryName = "Elite Trainer Box"},
                new Category { CategoryId = 3, CategoryName = "TCG Accessories"},
                new Category { CategoryId = 4, CategoryName = "Booster Packs"},
                new Category { CategoryId = 5, CategoryName = "Battle & Theme Decks"},
                new Category { CategoryId = 6, CategoryName = "Card Sleeves"}
            };
            return View(categories);
        }
    }
}