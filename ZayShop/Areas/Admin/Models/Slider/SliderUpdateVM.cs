using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Slider
{
    public class SliderUpdateVM 
    {
        [Required(ErrorMessage = "Ad daxil edilməlidir")]
        [MinLength(3, ErrorMessage = "Adın minimum uzunluğu 3 simvol olmalıdır")]
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    }
}
