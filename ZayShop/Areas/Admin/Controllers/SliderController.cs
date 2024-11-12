using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZayShop.Areas.Admin.Models.Category;
using ZayShop.Areas.Admin.Models.Product;
using ZayShop.Areas.Admin.Models.Slider;
using ZayShop.Data;
using ZayShop.Entities;

namespace ZayShop.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        #region List

        [HttpGet]
        public IActionResult Index()
        {
            var model = new SliderIndexVM
            {
                Sliders = _context.Sliders.ToList()
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
        public IActionResult Create(SliderCreateVM model)
        {
            if (!ModelState.IsValid) return View();
            

            var Slider = new Slider
            {
               Title=model.Title,   
               Subtitle=model.Subtitle,
               PhotoPath=model.PhotoPath,
               Description=model.Description,
            };

            _context.Sliders.Add(Slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion
        #region Update

        [HttpGet]
        public IActionResult Update(int id)
        {
            var Slider = _context.Sliders.Find(id);
            if (Slider is null) return NotFound();

            var model = new SliderUpdateVM
            {
                Title = Slider.Title,
                Subtitle = Slider.Subtitle,
                Description = Slider.Description,
                PhotoPath = Slider.PhotoPath,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, SliderUpdateVM model)
        {    
            if (!ModelState.IsValid) return View(model);

            var Slider = _context.Sliders.Find(id);
            if (Slider is null) return NotFound();

            Slider.Title = model.Title;
            Slider.PhotoPath = model.PhotoPath;
            Slider.Description = model.Description;
            Slider.Subtitle = model.Subtitle;
            Slider.ModifiedAt = DateTime.Now;

            _context.Sliders.Update(Slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion
        #region Delete

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Slider = _context.Sliders.Find(id);
            if (Slider is null) return NotFound();

            _context.Sliders.Remove(Slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
