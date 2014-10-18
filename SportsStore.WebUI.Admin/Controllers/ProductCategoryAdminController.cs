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
        public ViewResult Edit(int ProductCategoryID = 0)
        {
            ProductCategory productCategory = repository.ProductCategories.FirstOrDefault(model => model.ProductCategoryID == ProductCategoryID);
            var Categories = from cat in repository.Categories select cat;
            var Products = from prod in repository.Products select prod;
            List<SelectListItem> cats = new List<SelectListItem>();
            List<SelectListItem> prods = new List<SelectListItem>();
            foreach (var item in Categories)
            {
                if (productCategory != null && item.CategoryID == productCategory.CategoryID)
                {
                    cats.Add(new SelectListItem { Selected = true, Text = item.Name, Value = item.CategoryID.ToString() });
                }
                else
                {
                    cats.Add(new SelectListItem { Selected = false, Text = item.Name, Value = item.CategoryID.ToString() });
                }
            }
            foreach (var item in Products)
            {
                if (productCategory != null && item.ProductID == productCategory.ProductID)
                {
                    prods.Add(new SelectListItem { Selected = true, Text = item.Name, Value = item.ProductID.ToString() });
                }
                else
                {
                    prods.Add(new SelectListItem { Selected = false, Text = item.Name, Value = item.ProductID.ToString() });
                }

            }
            ViewData["CategoryList"] = cats;
            ViewData["ProductList"] = prods;
            if (productCategory != null)
            {
                return View(productCategory);
            }

            return View(new ProductCategory());
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