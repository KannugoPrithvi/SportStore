using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {           
            ViewBag.SelectedCategory = category;
            var tempCategoryViewModel = from pc in repository.ProductCategories
                                        join c in repository.Categories
                                        on
                                        pc.CategoryID equals c.CategoryID
                                        group c by new { c.CategoryID, c.Name } into result
                                        select new ProductCategoryViewModel
                                        {
                                            CategoryID = result.First().CategoryID,
                                            CategoryName = result.First().Name,
                                            ProductNos = result.Count()
                                        };
            List<ProductCategoryViewModel> lstOfProdCatViewModel = new List<ProductCategoryViewModel>();
            foreach (var item in tempCategoryViewModel)
            {
                lstOfProdCatViewModel.Add((ProductCategoryViewModel)item);
            }
            
            Dictionary<string, int> nameAndCount = new Dictionary<string, int>();


            ViewBag.TotalCount = lstOfProdCatViewModel.Sum(x => x.ProductNos);
            return PartialView("HorizontalMenu", lstOfProdCatViewModel);
        }
    }
}