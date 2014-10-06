using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class ProductWithImagesViewModel
    {
        public int ProductID { get; set; }
        public string Description { get; set; }
        public decimal AltPrice { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

    }
}