using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TvcLesson09Lap.Models.DataModels;
using TvcLesson09Lap.Models.DataViewModels;

namespace TvcLesson09Lap.Controllers
{
    public class TvcProductController : Controller
    {
        private static List<TvcProduct> _TvcProducts = new List<TvcProduct>();
        private static List<TvcCategory> _TvcCategories = new List<TvcCategory>()
        {
            new TvcCategory { Id = 1, Name = "Điện thoại" },
            new TvcCategory { Id = 2, Name = "Laptop" },
            new TvcCategory { Id = 3, Name = "Phụ kiện" }
        };

        // GET: TvcProductController
        public ActionResult Index()
        {
            return View(_TvcProducts);
        }

        // GET: TvcProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _TvcProducts.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: TvcProductController/Create
        public ActionResult Create()
        {
            var model = new TvcProductVM
            {
                Categories = new SelectList(_TvcCategories, "Id", "Name")
            };
            return View(model);
        }

        // POST: TvcProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TvcProductVM model)
        {
            try
            {
                // Validate logic SalePrice < Price * 0.9
                if (model.SalePrice >= model.Price * 0.9)
                {
                    ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn giá chuẩn 10%");
                }

                if (ModelState.IsValid)
                {
                    string imagePath = "";
                    // Xử lý upload ảnh
                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products");
                        if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                        var filePath = Path.Combine(uploadDir, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(stream);
                        }
                        imagePath = "/products/" + fileName;
                    }

                    // Chuyển đổi từ ViewModel sang Model để lưu trữ
                    var product = new TvcProduct
                    {
                        Id = _TvcProducts.Count > 0 ? _TvcProducts.Max(p => p.Id) + 1 : 1,
                        Name = model.Name,
                        Image = imagePath,
                        Price = model.Price,
                        SalePrice = model.SalePrice,
                        Description = model.Description,
                        CategoryId = model.CategoryId
                    };

                    _TvcProducts.Add(product);
                    return RedirectToAction(nameof(Index));
                }

                model.Categories = new SelectList(_TvcCategories, "Id", "Name", model.CategoryId);
                return View(model);
            }
            catch
            {
                model.Categories = new SelectList(_TvcCategories, "Id", "Name", model.CategoryId);
                return View(model);
            }
        }

        // GET: TvcProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _TvcProducts.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            // Chuyển đổi từ Model sang ViewModel
            var model = new TvcProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Image,
                Price = product.Price,
                SalePrice = product.SalePrice,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Categories = new SelectList(_TvcCategories, "Id", "Name", product.CategoryId)
            };
            return View(model);
        }

        // POST: TvcProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TvcProductVM model)
        {
            try
            {
                if (model.SalePrice >= model.Price * 0.9)
                {
                    ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn giá chuẩn 10%");
                }

                if (ModelState.IsValid)
                {
                    var existingProduct = _TvcProducts.FirstOrDefault(p => p.Id == id);
                    if (existingProduct != null)
                    {
                        existingProduct.Name = model.Name;
                        existingProduct.Price = model.Price;
                        existingProduct.SalePrice = model.SalePrice;
                        existingProduct.Description = model.Description;
                        existingProduct.CategoryId = model.CategoryId;

                        if (model.ImageFile != null && model.ImageFile.Length > 0)
                        {
                            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products");
                            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                            var filePath = Path.Combine(uploadDir, fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            existingProduct.Image = "/products/" + fileName;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                model.Categories = new SelectList(_TvcCategories, "Id", "Name", model.CategoryId);
                return View(model);
            }
            catch
            {
                model.Categories = new SelectList(_TvcCategories, "Id", "Name", model.CategoryId);
                return View(model);
            }
        }

        // GET: TvcProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _TvcProducts.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: TvcProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var product = _TvcProducts.FirstOrDefault(p => p.Id == id);
                if (product != null) _TvcProducts.Remove(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}