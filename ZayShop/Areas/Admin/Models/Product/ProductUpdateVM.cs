using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Product
{
    public class ProductUpdateVM
    {
        [Required(ErrorMessage = "Ad daxil edilməlidir")]
        [MinLength(3, ErrorMessage = "Adın minimum uzunluğu 3 simvol olmalıdır")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string Price { get; set; }
        public string PhotoPath { get; set; }
        public string Size { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        [Display(Name = "Category ")]
        public int CategoryId { get; set; }
    }
}
