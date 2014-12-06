using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductFeatureHeaderAndBody
    {
        public string FeatureHeader { get; set; }
        public string FeatureBody { get; set; }
    }
    public class ProductFeatureViewModelUI
    {
        public string ProductName { get; set; }
        public List<ProductFeatureHeaderAndBody> lstFeatureHeaderBody { get; set; }
    }
}