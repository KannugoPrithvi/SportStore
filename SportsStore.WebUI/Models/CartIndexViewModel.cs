using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public List<ProductCartList> lstProductCartList { get; set; }
    }
    public class ProductCartList
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}