using Microsoft.AspNetCore.Mvc;
using ZayShop.Data;
using ZayShop.Models.Shop;
using ZayShop.Models.Home;


namespace ZayShop.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Sliders = _context.Sliders.ToList();
            var SlidersList = new List<SliderVM>();

            foreach (var slider in Sliders)
            {
                var SliderVM = new SliderVM
                {
                    Title = slider.Title,
                    Subtitle = slider.Subtitle,
                    Description = slider.Description,
                    PhotoPath = slider.PhotoPath,
                };
                SlidersList.Add(SliderVM);
            }





            var model = new HomeIndexVM
            {
                Sliders = SlidersList
            };
            return View(model);
        }


    }

}
