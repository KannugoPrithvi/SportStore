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
        public ActionResult Edit(int ProductID = 0)
        {
            if (ProductID == 0)
            {
                TempData["Message"] = "No Such product exists";
                return RedirectToAction("Index", new { controller = "ProductAdmin" });
            }
            else
            {
                List<ProductCategory> productCategory = (repository.ProductCategories.Where(p => p.ProductID == ProductID)).ToList<ProductCategory>();
                var Products = from prod in repository.Products select prod;
                List<SelectListItem> prods = new List<SelectListItem>();
                foreach (var item in Products)
                {
                    if (item != null && item.ProductID == ProductID)
                    {
                        prods.Add(new SelectListItem { Selected = true, Text = item.Name, Value = item.ProductID.ToString() });
                    }
                    else
                    {
                        prods.Add(new SelectListItem { Selected = false, Text = item.Name, Value = item.ProductID.ToString() });
                    }
                }
                ViewData["ProductList"] = prods;
                return View(productCategory);
            }
        }

        //Post Product category Admin Edit
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProductCategory(productCategory);
                TempData["message"] = string.Format("Product Category has been saved successfully");
                return RedirectToAction("Index");
            }
            else
            {
                return View(productCategory);
            }
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit");
        }
    }
}