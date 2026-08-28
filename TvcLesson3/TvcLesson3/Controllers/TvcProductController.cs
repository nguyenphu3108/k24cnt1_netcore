using Microsoft.AspNetCore.Mvc;
using TvcLesson3.Models;

namespace TvcLesson3.Controllers
{
    public class TvcProductController : Controller
    {
        private readonly List<TvcProduct> _products = new()
        {
            new TvcProduct
            {
                TvcProductId = "G-001",
                TvcProductName = "Black Myth: Wukong",
                TvcYearRelease = "2024",
                TvcPrice = 60m
            },
            new TvcProduct
            {
                TvcProductId = "G-002",
                TvcProductName = "Elden Ring",
                TvcYearRelease = "2022",
                TvcPrice = 60m
            },
            new TvcProduct
            {
                TvcProductId = "G-003",
                TvcProductName = "Cyberpunk 2077",
                TvcYearRelease = "2020",
                TvcPrice = 60m
            },
            new TvcProduct
            {
                TvcProductId = "G-004",
                TvcProductName = "Baldur's Gate 3",
                TvcYearRelease = "2023",
                TvcPrice = 60m
            },
            new TvcProduct
            {
                TvcProductId = "G-005",
                TvcProductName = "Helldivers 2",
                TvcYearRelease = "2024",
                TvcPrice = 40m
            },
            new TvcProduct
            {
                TvcProductId = "G-006",
                TvcProductName = "The Witcher 3: Wild Hunt",
                TvcYearRelease = "2015",
                TvcPrice = 40m
            },
            new TvcProduct
            {
                TvcProductId = "G-007",
                TvcProductName = "Dark Souls III",
                TvcYearRelease = "2016",
                TvcPrice = 60m
            },
            new TvcProduct
            {
                TvcProductId = "G-008",
                TvcProductName = "Assassin's Creed Odyssey",
                TvcYearRelease = "2018",
                TvcPrice = 47m
            },
            new TvcProduct
            {
                TvcProductId = "G-009",
                TvcProductName = "Forza Horizon 5",
                TvcYearRelease = "2021",
                TvcPrice = 35m
            },
            new TvcProduct
            {
                TvcProductId = "G-010",
                TvcProductName = "Hogwarts Legacy",
                TvcYearRelease = "2023",
                TvcPrice = 50m
            }
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TvcGetAllProduct()
        {
            ViewData["products"] = _products;
            return View();
        }

        public IActionResult TvcGetListProduct()
        {
            return View(_products);
        }
    }
}
