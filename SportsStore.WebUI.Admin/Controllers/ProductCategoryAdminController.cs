using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Admin.Models;
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
        public ActionResult Edit(int ProductID = 0)
        {
            if (ProductID == 0)
            {
                TempData["Message"] = "No Such product exists";
                return RedirectToAction("Index", new { controller = "ProductAdmin" });
            }
            else
            {
                //List<ProductCategory> productCategory = (repository.ProductCategories.Where(p => p.ProductID == ProductID)).ToList<ProductCategory>();
                var categories = (from result in repository.Categories
                                 select new CategoryIDNameViewModel
                                 {
                                     CategoryID = result.CategoryID,
                                     CategoryName = result.Name,
                                     IsSelected = false
                                 }).ToList<CategoryIDNameViewModel>();
                ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();
                productCategoryViewModel.ProductID = ProductID;
                productCategoryViewModel.ProductName = repository.Products.Where(p => p.ProductID == ProductID).FirstOrDefault().Name;
                var checkedCategoriesList = (from result in repository.ProductCategories
                                                               where result.ProductID == ProductID
                                                               select new CategoryIDNameViewModel
                                                               {
                                                                   CategoryID = result.CategoryID,
                                                                   CategoryName = string.Empty,
                                                                   IsSelected = true
                                                               }).ToList<CategoryIDNameViewModel>();
                productCategoryViewModel.CategoryIDNameList = categories;
                return View(productCategoryViewModel);
            }
        }

        //Post Product category Admin Edit
        [HttpPost]
        public ActionResult Edit(ProductCategoryViewModel productCategoryViewModel)
        {
            var request = Request.Form;
            if (ModelState.IsValid)
            {
                //repository.SaveProductCategory(productCategoryViewModel);
                TempData["message"] = string.Format("Product Category has been saved successfully");
                return RedirectToAction("Index");
            }
            else
            {
                return View(productCategoryViewModel);
            }
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit");
        }
    }
}