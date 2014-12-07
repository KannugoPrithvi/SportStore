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
                foreach (var item in categories)
                {
                    foreach (var subItem in checkedCategoriesList)
                    {
                        if (subItem.CategoryID == item.CategoryID)
                        {
                            item.IsSelected = true;
                            break;
                        }
                    }
                }
                productCategoryViewModel.CategoryIDNameList = categories;
                return View(productCategoryViewModel);
            }
        }

        //Post Product category Admin Edit
        [HttpPost]
        public ActionResult Edit(ProductCategoryViewModel productCategoryViewModel)
        {
            //Very delicate logic under, need to test it extensively
            try
            {
                if (ModelState.IsValid && productCategoryViewModel != null)
                {
                    var productCategoryFromDB = (from result in repository.ProductCategories
                                                 where result.ProductID == productCategoryViewModel.ProductID
                                                 select new CategoryIDNameViewModel
                                                 {
                                                     CategoryID = result.CategoryID,
                                                     IsSelected = true
                                                 }).ToList<CategoryIDNameViewModel>();
                    var productCategoryFromModel = productCategoryViewModel.CategoryIDNameList;

                    if (productCategoryFromDB.Count > 0)
                    {
                        //Generate Delete Product Category List

                        int flag = 0;
                        foreach (var item in productCategoryFromDB)
                        {
                            flag = 0;
                            foreach (var subItem in productCategoryFromModel)
                            {
                                if (subItem.CategoryID == item.CategoryID && subItem.IsSelected == true)
                                {
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 0)
                            {
                                repository.DeleteProductCategory(new ProductCategory { CategoryID = item.CategoryID, ProductID = productCategoryViewModel.ProductID });
                            }
                        }
                        //Generate Insert Product Category List
                        foreach (var item in productCategoryFromModel)
                        {
                            flag = 0;
                            foreach (var subItem in productCategoryFromDB)
                            {
                                if (item.CategoryID != subItem.CategoryID && item.IsSelected == true)
                                {
                                    flag = 1;
                                }
                                else
                                {
                                    flag = 0;
                                    break;
                                }
                            }
                            if (flag == 1)
                            {
                                repository.SaveProductCategory(new ProductCategory { CategoryID = item.CategoryID, ProductID = productCategoryViewModel.ProductID });
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in productCategoryFromModel)
                        {
                            if (item.IsSelected == true)
                            {
                                repository.SaveProductCategory(new ProductCategory { CategoryID = item.CategoryID, ProductID = productCategoryViewModel.ProductID });
                            }
                        }
                    }
                    return RedirectToAction("Index", new { controller = "ProductAdmin" });
                }
                else
                {
                    return View(productCategoryViewModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit");
        }
    }
}
