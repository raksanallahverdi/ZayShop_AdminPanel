using Microsoft.AspNetCore.Mvc;
using ZayShop.Models.Shop;
using ZayShop.Data;
using ZayShop.Models.About;

namespace ZayShop.Controllers
{

    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            var CategoriesList = new List<CategoryVM>();

            foreach (var category in categories)
            {
                var CategoryVM = new CategoryVM
                {
                    Name = category.Name
                };
                CategoriesList.Add(CategoryVM);
            }
          




            var model = new ShopIndexVM
            {
              Categories=CategoriesList
            };
            return View(model);
        }




    }
}
