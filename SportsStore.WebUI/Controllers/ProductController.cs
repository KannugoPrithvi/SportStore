using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 8;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(int CategoryID = 0, string CategoryName = null, int page = 1)
        {
            IEnumerable<ProductImageViewModel> result;
            if (CategoryID != 0)
            {
                result = from P in repository.Products
                         join I in repository.Images
                         on
                         P.ProductID equals I.ProductID
                         join PC in repository.ProductCategories
                         on
                         P.ProductID equals PC.ProductID
                         where PC.CategoryID == CategoryID
                         select new ProductImageViewModel
                         {
                             ProductID = P.ProductID,
                             ShortDescription = P.ShortDescription,
                             Name = P.Name,
                             AltPrice = P.AltPrice,
                             ImagePath = I.MediumImage
                         };
            }
            else
            {
                //You need to do Left out join in future

                result = from P in repository.Products
                         join I in repository.Images
                         on
                         P.ProductID equals I.ProductID
                         select new ProductImageViewModel
                         {
                             ProductID = P.ProductID,
                             ShortDescription = P.ShortDescription,
                             Name = P.Name,
                             AltPrice = P.AltPrice,
                             ImagePath = I.MediumImage
                         };
            }
            ProductsListViewModel model = new ProductsListViewModel
            {
                ProductsAndImages = result
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrentPage = page,
                    TotalItems = CategoryID == 0 ? repository.Products.Count() : result.Count()
                },
                CurrentCategoryID = CategoryID
            };
            ViewBag.SelectedCategory = CategoryName;
            return View(model);
        }


        public FileContentResult GetImage(int productId)
        {
            //Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            //if(prod != null)
            //{
            //    return File(prod.ImageData, prod.ImageMimeType);
            //}
            //else
            //{
            //    return null;
            //}
            return null;
        }
    }
}