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
        public string Price { get; set; }
        public string PhotoPath { get; set; }
        public string Size { get; set; }
        [Display(Name = "Product Category")]
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
