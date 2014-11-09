using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Admin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        private IProductRepository repository;
        public ProductAdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }
        [HttpGet]
        public ActionResult Edit(int productId)
        {
            if (productId != 0)
            {
                Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted ", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UploadImage(int ProductID = 0)
        {
            if (ProductID == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Image image = repository.Images.FirstOrDefault(p => p.ProductID == ProductID);
                return View("UploadImageTemp", new ImageUploadViewModel { Product = image.Product});
            }
        }
        [HttpPost]
        public ActionResult UploadImage(ImageUploadViewModel imageUploadViewModel)
        {
            if (ModelState.IsValid && imageUploadViewModel != null)
            {
                Image image = new Image();
                string applicationPath = ConfigurationManager.AppSettings["ImagePath"].ToString();

                //Storing Small Image Path
                if (imageUploadViewModel.SmallImage != null)
                {
                    string smallImageFileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.SmallImage.FileName);
                    string smallImageFilePath = Path.Combine(applicationPath, smallImageFileName);
                    image.SmallImage = smallImageFilePath;
                }


                //Storing Medium Image Path
                if (imageUploadViewModel.MediumImage != null)
                {
                    string mediumImageFileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.MediumImage.FileName);
                    string mediumImageFilePath = Path.Combine(applicationPath, mediumImageFileName);
                    image.MediumImage = mediumImageFilePath;
                }

                //Storing Large Image Path
                if (imageUploadViewModel.LargeImage != null)
                {
                    string largeImageFileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.MediumImage.FileName);
                    string largeImageFilePath = Path.Combine(applicationPath, largeImageFileName);
                    image.LargeImage = largeImageFilePath;
                }

                //Storing Extra Image Path
                if (imageUploadViewModel.ExtraImage != null)
                {
                    string extraImageFileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.MediumImage.FileName);
                    string extraImageFilePath = Path.Combine(applicationPath, extraImageFileName);
                    image.ExtraImage0 = extraImageFilePath;
                }


                //Storing Extra Image1 Path
                if (imageUploadViewModel.ExtraImage1 != null)
                {
                    string extraImage1FileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.MediumImage.FileName);
                    string extraImage1FilePath = Path.Combine(applicationPath, extraImage1FileName);
                    image.ExtraImage1 = extraImage1FilePath;
                }

                //Storing Extra Image2 Path
                if (imageUploadViewModel.ExtraImage2 != null)
                {
                    string extraImage2FileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.MediumImage.FileName);
                    string extraImage2FilePath = Path.Combine(applicationPath, extraImage2FileName);
                    image.ExtraImage2 = extraImage2FilePath;
                }
                image.ProductID = imageUploadViewModel.ProductID;

                repository.SaveImage(image);
                TempData["Message"] = "Image successfully stored for " + image.Product.Name;
                return View("Index");
            }
            else
            {
                return View(imageUploadViewModel);
            }
        }

    }
}