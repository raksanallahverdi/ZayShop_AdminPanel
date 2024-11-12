using Microsoft.AspNetCore.Mvc;
using ZayShop.Data;
using ZayShop.Areas.Admin.Models.Category;

using ZayShop.Entities;


namespace ZayShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        #region List

        [HttpGet]
        public IActionResult Index()
        {
            var model = new CategoryIndexVM
            {
                Categories = _context.Categories.ToList()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateVM model)
        {
            if (!ModelState.IsValid) return View();

            var Category = _context.Categories.FirstOrDefault(wc => wc.Name.ToLower() == model.Name.ToLower());
            if (Category is not null)
            {
                ModelState.AddModelError("Name", "Bu adda kateqoriya mövcuddur");
                return View();
            }

            Category = new Category
            {
                Name = model.Name
            };

            _context.Categories.Add(Category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Update

        [HttpGet]
        public IActionResult Update(int id)
        {
            var Category = _context.Categories.Find(id);
            if (Category is null) return NotFound();

            var model = new CategoryUpdateVM
            {
                Name = Category.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, CategoryUpdateVM model)
        {
            if (!ModelState.IsValid) return View();

            var Category = _context.Categories.Find(id);
            if (Category is null) return NotFound();

            var isExist = _context.Categories.Any(wc => wc.Name.ToLower() == model.Name.ToLower() && wc.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda kateqoriya mövcuddur");
                return View();
            }

            if (Category.Name != model.Name)
                Category.ModifiedAt = DateTime.Now;

            Category.Name = model.Name;

            _context.Categories.Update(Category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Category = _context.Categories.Find(id);
            if (Category is null) return NotFound();

            _context.Categories.Remove(Category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
