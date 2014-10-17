using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Admin.Controllers
{
    public class ProductCategoryAdminController : Controller
    {
        IProductRepository repository;
        public ProductCategoryAdminController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: ProductCategoryAdmin
        public ActionResult Index()
        {
            return View(repository.ProductCategories);
        }

        //Get Product Category Admin Edit
        [HttpGet]
        public ViewResult Edit(int ProductCategoryID)
        {
            ProductCategory productCategory = repository.ProductCategories.FirstOrDefault(model => model.ProductCategoryID == ProductCategoryID);
            if(productCategory != null)
            {
                return View(productCategory);
            }
            return View(new ProductCategory());
        }
        
        //Post Product category Admin Edit
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if(ModelState.IsValid)
            {
                repository.SaveProductCategory(productCategory);
                TempData["message"] =string.Format("ProductCategory has been saved successfully");
                return RedirectToAction("Index");
            }
            else
            {
                return View(productCategory);
            }
        }
    }
}