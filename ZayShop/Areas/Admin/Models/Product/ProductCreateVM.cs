using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using ZayShop.Models;
namespace ZayShop.Areas.Admin.Models.Product
{
    public class ProductCreateVM
    {
        [Required(ErrorMessage = "Please Enter Category Name")]
        [MinLength(3, ErrorMessage = "Minimum length must be 3 symbols")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price must be entered !")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Size must be entered !")]
        public string Size { get; set; }
        [Display(Name = "Product Category")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Photo must be entered !")]

        public IFormFile Photo { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
