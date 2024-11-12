using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Category
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage = "Please Enter Category Name")]
        [MinLength(3, ErrorMessage = "Minimum length must be 3 symbols")]
        
        public string Name { get; set; }
    }
}
