using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Category
{
    public class CategoryUpdateVM
    {
        [Required(ErrorMessage = "Ad daxil edilməlidir")]
        [MinLength(3, ErrorMessage = "Adın minimum uzunluğu 3 simvol olmalıdır")]
        [Display(Name = "Title")]
        public string Name { get; set; }
    }
}
