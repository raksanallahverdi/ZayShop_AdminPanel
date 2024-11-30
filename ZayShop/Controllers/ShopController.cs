using Microsoft.AspNetCore.Mvc;
using ZayShop.Models.Shop;
using ZayShop.Data;
using ZayShop.Models.About;
using System.Drawing;
using ZayShop.Entities;

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
                    Name = category.Name,
                    Id=category.Id
                };
                CategoriesList.Add(CategoryVM);
            }

            var products=_context.Products.ToList();
            var productsList = new List<ProductVM>();
            foreach (var product in products)
            {
                var ProductVM = new ProductVM
                {
                    Title = product.Title,
                    Price = product.Price,
                    PhotoName = product.PhotoName,
                    Size = product.Size,
                    Category = product.Category,
                    CategoryId = product.CategoryId


                };
                productsList.Add(ProductVM);
            }
          




            var model = new ShopIndexVM
            {
              Categories=CategoriesList,
              Products=productsList
            };
            return View(model);
        }


        public IActionResult getProductByCategory(int categoryId)
        {

           

            var products = _context.Products.Where(p => p.CategoryId == categoryId).ToList();
            return PartialView("_ProductPartial",products);
        }

    }
}
