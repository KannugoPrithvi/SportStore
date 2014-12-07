using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.ViewModels;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class CombinedProductSpecificationViewModel
    {
        public Product Product { get; set; }
        public ProductSpecificationViewModel ProductSpecificationViewModel { get; set; }
    }
}