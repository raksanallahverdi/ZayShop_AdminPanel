﻿using Microsoft.AspNetCore.Mvc;

namespace ZayShop.Models.Shop
{
    public class ShopIndexVM
    {
      public List<CategoryVM> Categories { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
