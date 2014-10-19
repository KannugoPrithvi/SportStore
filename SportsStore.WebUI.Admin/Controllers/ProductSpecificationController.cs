using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Admin.Controllers
{
    public class ProductSpecificationController : Controller
    {
        IProductRepository repository;

        public ProductSpecificationController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            ProductSpecificationDetails specDetails = new ProductSpecificationDetails();
            specDetails.ProductSpecHeading = "General Specifications";
            specDetails.ProductSpecOrder = 1;
            specDetails.ProductConfigurationDetails = GetConfigurationList();
            return View("ProductSpecificationList",specDetails);
        }
        
        [HttpPost]
        public ActionResult Edit(ProductSpecificationDetails ProdSpecDetails)
        {
            var request = Request.Form;
            ProductSpecificationDetails temp = ProdSpecDetails;
            return View(ProdSpecDetails);
        }

        [ChildActionOnly]
        public ActionResult ProductSpecification()
        {
            return PartialView("Partial/ProductSpecification");
        }
        private List<ProductSubConfigurationDetails> GetConfigurationList()
        {
            List<ProductSubConfigurationDetails> configurationList = new List<ProductSubConfigurationDetails>();
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_1", SubSpec = "Name_Value_1" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_2", SubSpec = "Name_Value_2" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_3", SubSpec = "Name_Value_3" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_4", SubSpec = "Name_Value_4" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_5", SubSpec = "Name_Value_5" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_6", SubSpec = "Name_Value_6" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_7", SubSpec = "Name_Value_7" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_8", SubSpec = "Name_Value_8" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_10", SubSpec = "Name_Value_10" });
            return configurationList;
        }
    }
}