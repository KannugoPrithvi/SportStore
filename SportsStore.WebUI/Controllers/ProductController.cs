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

        public ViewResult List(int CategoryID,int page = 1)
        {
            IEnumerable<int> ProductCount;
            IEnumerable<Product> Products;
            if(CategoryID !=0)
            {
                var result = repository.ProductCategories
                    .Where(x => x.CategoryID == CategoryID)
                    .Select(x => x.ProductID);
                ProductCount = result.ToList();

                foreach (int item in result)
                {
                    Products.Add
                }
            }
            
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrentPage = page,
                    TotalItems = CategoryID == 0 ? repository.Products.Count() : ProductCount.Count()
                },
                CurrentCategory = category
            };
            return null;
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