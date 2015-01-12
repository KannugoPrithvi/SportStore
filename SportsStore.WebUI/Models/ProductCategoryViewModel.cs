using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductCategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductNos { get; set; }
    }
    public class ProductImageViewModel
    {
        public int ProductID { get; set; }
        public string ShortDescription { get; set; }
        public decimal AltPrice { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
    public class ProductSliderPartialViewModel
    {
        public ProductImageViewModel productImageViewModel { get; set; }
        public ProductCategoryViewModel productCategoryViewModel { get; set; }
    }
}