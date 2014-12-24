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
                if (image != null)
                {
                    ViewBag.ProductName = image.Product.Name;
                }
                else
                {
                    ViewBag.ProductName = "New Product";
                }
            
                return View("UploadImage", new ImageUploadViewModel());
            }
        }
        [HttpPost]
        public ActionResult UploadImage(ImageUploadViewModel imageUploadViewModel)
        {
            if (ModelState.IsValid && imageUploadViewModel != null)
            {
                Image image = repository.Images.FirstOrDefault(p => p.ProductID == imageUploadViewModel.ProductID);
                if(image == null)
                {
                    image = new Image();
                }
                string applicationPath = ConfigurationManager.AppSettings["ImagePath"].ToString();
                //Storing image description
                image.ImageDescription = imageUploadViewModel.ImageDescription;

                //Storing Small Image Path
                if (imageUploadViewModel.SmallImage != null)
                {
                    string smallImageFileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.SmallImage.FileName);
                    string smallImageFilePath = Path.Combine(Server.MapPath(applicationPath), smallImageFileName);
                    image.SmallImage = string.Format(@"http://localhost:49217/Content/images/cart-image-icons/{0}", smallImageFileName);
                    imageUploadViewModel.SmallImage.SaveAs(smallImageFilePath);
                }
                else
                {
                    image.SmallImage = null;
                }


                //Storing Medium Image Path
                if (imageUploadViewModel.MediumImage != null)
                {
                    string mediumImageFileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.MediumImage.FileName);
                    string mediumImageFilePath = Path.Combine(Server.MapPath(applicationPath), mediumImageFileName);
                    //Temporary Adjustment for image path storing
                    //Change the below URL for respective environment
                    image.MediumImage = string.Format(@"http://localhost:49217/Content/images/cart-image-icons/{0}", mediumImageFileName);
                    //image.MediumImage = mediumImageFilePath;
                    imageUploadViewModel.MediumImage.SaveAs(mediumImageFilePath);
                }
                else
                {
                    image.MediumImage = null;
                }

                //Storing Large Image Path
                if (imageUploadViewModel.LargeImage != null)
                {
                    string largeImageFileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.LargeImage.FileName);
                    string largeImageFilePath = Path.Combine(Server.MapPath(applicationPath), largeImageFileName);
                    image.LargeImage = string.Format(@"http://localhost:49217/Content/images/cart-image-icons/{0}",largeImageFileName);
                    imageUploadViewModel.LargeImage.SaveAs(largeImageFilePath);
                }
                else
                {
                    image.LargeImage = null;
                }

                //Storing Extra Image Path
                if (imageUploadViewModel.ExtraImage != null)
                {
                    string extraImageFileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.ExtraImage.FileName);
                    string extraImageFilePath = Path.Combine(Server.MapPath(applicationPath), extraImageFileName);
                    image.ExtraImage0 = string.Format(@"http://localhost:49217/Content/images/cart-image-icons/{0}", extraImageFileName);
                    imageUploadViewModel.ExtraImage.SaveAs(extraImageFilePath);
                }
                else
                {
                    image.ExtraImage0 = null;
                }

                //Storing Extra Image1 Path
                if (imageUploadViewModel.ExtraImage1 != null)
                {
                    string extraImage1FileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.ExtraImage1.FileName);
                    string extraImage1FilePath = Path.Combine(Server.MapPath(applicationPath), extraImage1FileName);
                    image.ExtraImage1 = string.Format(@"http://localhost:49217/Content/images/cart-image-icons/{0}", extraImage1FileName);
                    imageUploadViewModel.ExtraImage1.SaveAs(extraImage1FilePath);
                }
                else 
                {
                    image.ExtraImage1 = null;
                }


                //Storing Extra Image2 Path
                if (imageUploadViewModel.ExtraImage2 != null)
                {
                    string extraImage2FileName = Guid.NewGuid().ToString() + Path.GetFileName(imageUploadViewModel.ExtraImage2.FileName);
                    string extraImage2FilePath = Path.Combine(Server.MapPath(applicationPath), extraImage2FileName);
                    image.ExtraImage2 = string.Format(@"http://localhost:49217/Content/images/cart-image-icons/{0}", extraImage2FileName);
                    imageUploadViewModel.ExtraImage2.SaveAs(extraImage2FilePath);
                }
                else
                {
                    image.ExtraImage2 = null;
                }
                image.ProductID = imageUploadViewModel.ProductID;

                repository.SaveImage(image);
                TempData["Message"] = "Image successfully saved ";
                return RedirectToAction("Index");
            }
            else
            {
                return View(imageUploadViewModel);
            }
        }

    }
}