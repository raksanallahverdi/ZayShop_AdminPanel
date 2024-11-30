using ZayShop.Entities;

namespace ZayShop.Models.Shop
{
    public class ProductVM
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public string PhotoName { get; set; }
        public string Size { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
