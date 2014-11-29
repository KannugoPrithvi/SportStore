using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Admin.Models
{
    public class ProductFeatureHeaderBody
    {
        public int ProductFeatureID { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
    }
    public class ProductFeatureViewModel
    {
        public int ProductID { get; set; }
        public List<ProductFeatureHeaderBody> lstProductFeatureHeaderBody { get; set; }
    }
}