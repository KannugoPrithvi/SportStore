using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Admin.Models
{
    public class ImageUploadViewModel
    {
        [Required]
        [Display(Name="Product Name")]
        public int ProductID { get; set; }
        [Required]
        [Display(Name="Medium Size Image")]
        public HttpPostedFileBase MediumImage { get; set; }
        [Display(Name="Small Image")]
        public HttpPostedFileBase SmallImage { get; set; }
        [Display(Name="Large Image")]
        public HttpPostedFileBase LargeImage { get; set; }
        [Display(Name="Extra Image")]
        public HttpPostedFileBase ExtraImage { get; set; }
        [Display(Name="Extra Image 1")]
        public HttpPostedFileBase ExtraImage1 { get; set; }
        [Display(Name="Extra Image 2")]
        public HttpPostedFileBase ExtraImage2 { get; set; }
        [Display(Name="Image Description")]
        public string ImageDescription { get; set; }
        
    }
}