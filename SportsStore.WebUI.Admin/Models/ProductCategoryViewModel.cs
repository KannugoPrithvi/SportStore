using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Admin.Models
{
    public class ProductCategoryViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public List<CategoryIDNameViewModel> CategoryIDNameList { get; set; }
    }
    public class CategoryIDNameViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsSelected { get; set; }
    }
}