using Microsoft.AspNetCore.Mvc;

namespace ZayShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
