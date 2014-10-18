using SportsStore.Domain.Abstract;
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
            return null;
        }
    }
}