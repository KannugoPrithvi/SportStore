using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.Domain.Entities
{
    public class Product
    {
        //[HiddenInput(DisplayValue=false)]
        //public int ProductID { get; set; }
        //[Required(ErrorMessage="Please enter a product name")]
        //public string Name { get; set; }
        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage="Please enter a description")]
        //public string Description { get; set; }
        //[Required]
        //[Range(0.01,double.MaxValue,ErrorMessage="Please enter a positiive price")]
        //public decimal Price { get; set; }
        //[Required(ErrorMessage="Please specify a category")]
        //public string Category { get; set; }
        //public byte[] ImageData { get; set; }
        //public string ImageMimeType { get; set; }
        //public string ImagePath { get; set; }


        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        public string Keywords { get; set; }
        [Required(ErrorMessage="Please enter a short description")]
        public string ShortDescription { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage="Please select either yes or no")]
        public bool IsDiscontinued { get; set; }
        public bool InStock { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage="Please enter a positive value")]
        public decimal UnitCost { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public decimal AltPrice { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public decimal Weight { get; set; }
        
        public string Header { get; set; }
        public string Footer { get; set; }
        [Required(ErrorMessage="Please select yes or no")]
        public bool IsTaxed { get; set; }
        [Required]
        [HiddenInput(DisplayValue=false)]
        public int CategoryID { get; set; }
        public int MaximumProductQuantity { get; set; }
        [Required(ErrorMessage="Please enter a integer value to show in order in case similar products are shown in the list")]
        public int ProductOrder { get; set; }      
       
       
    }

}
