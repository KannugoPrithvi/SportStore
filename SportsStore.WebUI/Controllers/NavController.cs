using SportsStore.Domain.Abstract;
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
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            Dictionary<string, int> nameAndCount = new Dictionary<string, int>();            
            foreach (var item in categories)
            {                
                nameAndCount[item] = repository.Products.Count(x => x.Category == item);
            }

            ViewBag.TotalCount = repository.Products.Count();
            return PartialView("HorizontalMenu", nameAndCount);
        }
    }
}