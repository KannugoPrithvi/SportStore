using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductImageViewModel> ProductsAndImages { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategoryID { get; set; }
    }
}