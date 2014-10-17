using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Admin.Controllers
{
    public class CategoryAdminController : Controller
    {
        IProductRepository repository;

        public CategoryAdminController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(repository.Categories);
        }
        [HttpGet]
        public ViewResult Edit(int categoryID)
        {
            Category category = repository.Categories.FirstOrDefault(p => p.CategoryID == categoryID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                repository.SaveCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Category());
        }

        [HttpPost]
        public ActionResult Delete(int categoryID)
        {
            Category category = repository.DeleteCategory(categoryID);
            if(category != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", category.Name);
            }
            return RedirectToAction("Index");
        }
    }
}