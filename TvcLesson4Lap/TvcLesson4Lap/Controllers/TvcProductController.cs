using Microsoft.AspNetCore.Mvc;
using TvcLesson4Lap.Models;

namespace TvcLesson4Lap.Controllers
{
    [Route("/TvcProduct", Name = "product")]
    public class TvcProductController : Controller
    {
        private readonly List<TvcCategory> tvcCategories = new()
        {
            new TvcCategory { Id = 1, Name = "Nhập Vai" },
            new TvcCategory { Id = 2, Name = "Thế Giới Mở" },
            new TvcCategory { Id = 3, Name = "Hành Động" },
            new TvcCategory { Id = 4, Name = "Chiến Thuật" },
            new TvcCategory { Id = 5, Name = "Đua Xe" },
            new TvcCategory { Id = 6, Name = "RPG" },
        };
        private readonly List<TvcProduct> tvcProducts = new()
            {
                new TvcProduct
                {
                    Id = 1,
                    Name = "Cyberpunk 2077",
                    Image = "/images/C2077.jpg",
                    Price = 1200000,
                    SalePrice = 799000,
                    CategoryId = 1,
                    Description = "Game nhập vai hành động thế giới mở lấy bối cảnh Night City, nơi người chơi hóa thân thành V và khám phá một tương lai công nghệ đầy biến động.",
                    Status = "Còn Hàng",
                    CreateAt = new DateTime(2020, 8, 1)
                },

                new TvcProduct
                {
                    Id = 2,
                    Name = "Red Dead Redemption 2",
                    Image = "/images/RDR2.jpg",
                    Price = 1500000,
                    SalePrice = 899000,
                    CategoryId = 2,
                    Description = "Game hành động phiêu lưu thế giới mở kể về cuộc hành trình của Arthur Morgan và băng đảng Van der Linde tại miền Tây nước Mỹ.",
                    Status = "Còn Hàng",
                    CreateAt = new DateTime(2020, 12, 10)
                },

                new TvcProduct
                {
                    Id = 3,
                    Name = "God of War Ragnarök",
                    Image = "/images/GOWR.jpg",
                    Price = 1400000,
                    SalePrice = 999000,
                    CategoryId = 3,
                    Description = "Kratos và Atreus tiếp tục hành trình khám phá thần thoại Bắc Âu, đối mặt với những thế lực mạnh mẽ và định mệnh của Ragnarök.",
                    Status = "Còn Hàng",
                    CreateAt = new DateTime(2022, 11, 9)
                },

                new TvcProduct
                {
                    Id = 4,
                    Name = "Baldur's Gate 3",
                    Image = "/images/BG3.webp",
                    Price = 1300000,
                    SalePrice = 949000,
                    CategoryId = 4,
                    Description = "Game nhập vai chiến thuật với cốt truyện phong phú, hệ thống lựa chọn đa dạng và thế giới fantasy rộng lớn.",
                    Status = "Còn Hàng",
                    CreateAt = new DateTime(2023, 8, 3)
                },

                new TvcProduct
                {
                    Id = 5,
                    Name = "Forza Horizon 5",
                    Image = "/images/FH5.jpg",
                    Price = 1100000,
                    SalePrice = 699000,
                    CategoryId = 5,
                    Description = "Game đua xe thế giới mở với hàng trăm mẫu xe, bản đồ rộng lớn và những cuộc đua tốc độ cao tại Mexico.",
                    Status = "Còn Hàng",
                    CreateAt = new DateTime(2021,11, 9)
                },

                new TvcProduct
                {
                    Id = 6,
                    Name = "Starfield",
                    Image = "/images/SF.jpg",
                    Price = 1300000,
                    SalePrice = 799000,
                    CategoryId = 6,
                    Description = "Game nhập vai khoa học viễn tưởng cho phép người chơi khám phá vũ trụ rộng lớn, các hành tinh và nhiều nền văn minh khác nhau.",
                    Status = "Còn Hàng",
                    CreateAt = new DateTime(2023, 9, 6)
                }
            };

        public IActionResult Index(int? categoryId)
        {
            var filteredProducts = tvcProducts;
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                filteredProducts = tvcProducts.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.TvcProduct = filteredProducts;
            ViewBag.TvcCategories = tvcCategories;
            ViewBag.SelectedCategory = categoryId ?? 0;
            return View();
        }

        [Route("san-pham", Name = "tvcSanpham")]
        public IActionResult TvcSanpham(int? id)
        {
            TvcProduct tvcProduct = new TvcProduct
            {
                Id = 1,
                Name = "Cyberpunk 2077",
                Image = "/images/C2077.jpg",
                Price = 1200000,
                SalePrice = 799000,
                CategoryId = 1,
                Description = "Game nhập vai hành động thế giới mở lấy bối cảnh Night City, nơi người chơi hóa thân thành V và khám phá một tương lai công nghệ đầy biến động.",
                Status = "Còn Hàng",
                CreateAt = new DateTime(2026, 8, 1)
            };
            if (id != null)
                tvcProduct = tvcProducts.FirstOrDefault(x => x.Id == id);

            ViewBag.TvcProduct = tvcProduct;
            ViewBag.TvcCategories = tvcCategories;
            return View();
        }
    }
}
