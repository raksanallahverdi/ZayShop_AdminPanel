using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using ZayShop.Areas.Admin.Models.Category;
using ZayShop.Areas.Admin.Models.Product;
using ZayShop.Data;

using ZayShop.Entities;
using ZayShop.Utilities.File;



namespace ZayShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;
      
        public ProductController(AppDbContext context,IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        #region List

        [HttpGet]
        public IActionResult Index()
        {

            var model = new ProductIndexVM
            {
                Products = _context.Products.Include(p => p.Category).ToList()
            };
            return View(model);
        }

        #endregion
        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductCreateVM
            {
                Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVM model)
        {
            if (!ModelState.IsValid) return View(model);


            if (!_fileService.isImage(model.Photo.ContentType))
            {
                ModelState.AddModelError("Photo", "File Type Error");

            }
            if (_fileService.isAvailableSize(model.Photo.Length))
            {
                ModelState.AddModelError("Photo", "Photo Size Limit Exceeded");
            }
            var photoName= _fileService.Upload(model.Photo,"assets/img");

         

            model.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            if (!ModelState.IsValid) return View(model);

            var Product = _context.Products.FirstOrDefault(wc => wc.Title.ToLower() == model.Title.ToLower());
            if (Product is not null)
            {
                ModelState.AddModelError("Name", "Bu adda Product mövcuddur");
                return View(model);
            }
            var Category = _context.Categories.Find(model.CategoryId);
            if (Category is null)
            {
                ModelState.AddModelError("CategoryId", "Secilmis kateqoriya is not found");
                return View(model);
            }

            Product = new Product
            {
                Title = model.Title,
                Price = model.Price,
                Size = model.Size,
                CategoryId = model.CategoryId,
                PhotoName=photoName

            };

            _context.Products.Add(Product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion
        #region Update

        [HttpGet]
        public IActionResult Update(int id)
        {

            var Product = _context.Products.Find(id);
            if (Product is null) return NotFound();

            var model = new ProductUpdateVM
            {
                Title = Product.Title,
                PhotoName = Product.PhotoName,
                Price = Product.Price,
                Size = Product.Size,
              
                CategoryId = Product.CategoryId,
                Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList()

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, ProductUpdateVM model)
        {
            model.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            if (!ModelState.IsValid) return View(model);


            var Product = _context.Products.Find(id);
            if (Product is null) return NotFound();

            var isExist = _context.Products.Any(p => p.Title.ToLower() == model.Title.ToLower() && p.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda Product mövcuddur");
                return View(model);
            }

            var productCategory = _context.Categories.Find(model.CategoryId);
            if (productCategory is null) return NotFound();
            if (model.Photo != null)
            {

                if (!_fileService.isImage(model.Photo.ContentType))
                    ModelState.AddModelError("Photo", "Invalid Format");
                if (!_fileService.isAvailableSize(model.Photo.Length))
                    ModelState.AddModelError("Photo", "Size Photo Exceeded");

                _fileService.Delete("assets/img", Product.PhotoName);
                Product.PhotoName = _fileService.Upload(model.Photo, "assets/img");


            }





            Product.Title = model.Title;
            Product.Price = model.Price;
            Product.Size = model.Size;
            Product.CategoryId = productCategory.Id;
            Product.ModifiedAt = DateTime.Now;

       

            _context.Products.Update(Product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion
        #region Delete

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Product = _context.Products.Find(id);
            if (Product is null) return NotFound();

            _context.Products.Remove(Product);
            _context.SaveChanges();
            _fileService.Delete("assets/img", Product.PhotoName);

            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
