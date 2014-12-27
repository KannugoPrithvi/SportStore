using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.ViewModels;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class QuickViewController : Controller
    {
        IProductRepository repository;
        public QuickViewController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: QuickView
        //The below view has to be made parallel and include all the features like product specification, product reviews, product ratings,related products
        //all at once. Need to write different methods for each one of them
        //Need to create a combined view model to send to this View,as of now only sending productspecification but would change overtime
        public ActionResult ProductView(int ProductID = 0)
        {
            if(ProductID == 0)
            {
                TempData["Message"] = "No such product exists";
                return View();
            }
            else
            {
                //The below model is for ProductSpecification
                CombinedProductSpecificationViewModel combinedProductSpecificationViewModel = ReturnProductSpecification(ProductID);
                return View("ProductView",combinedProductSpecificationViewModel);
            }
            
        }
        [ChildActionOnly]
        public PartialViewResult ProductFeaturePartial(int ProductID = 0)
        {
            if(ProductID == 0)
            {
                return PartialView("Partial/General/_ProductFeature", null);
            }
            else
            {
                var lstFeatureHeaderBody = (from result in repository.ProductFeatures
                                            where result.ProductID == ProductID
                                            select new ProductFeatureHeaderAndBody
                                            {
                                                FeatureHeader = result.ProductFeatureHeader,
                                                FeatureBody = result.ProductFeatureBody
                                            }).ToList<ProductFeatureHeaderAndBody>();
                ProductFeatureViewModelUI productFeatureViewModel = new ProductFeatureViewModelUI
                {
                    ProductName = repository.Products.FirstOrDefault(p => p.ProductID == ProductID).Name,
                    lstFeatureHeaderBody = lstFeatureHeaderBody
                };

                return PartialView("Partial/General/_ProductFeature", productFeatureViewModel);
            }
        }
        [ChildActionOnly]
        public PartialViewResult ProductSpecificationPartial(int ProductID = 0)
        {
            if (ProductID == 0)
            {
                return PartialView("Partial/_ProductSpecification", null);
            }
            else
            {
                //var prodSpecViewModel = 
                return PartialView("Partial/_ProductSpecification");
            }
        }
        public CombinedProductSpecificationViewModel ReturnProductSpecification(int ProductID = 0)
        {
            //The below code has to be moved to a different function or a method
            var result = from ps in repository.ProductSpecifications
                         join psa in repository.ProductSpecificationAttributes
                         on ps.ProductSpecificationID equals psa.ProductSpecificationID
                         where ps.ProductID == ProductID
                         select new
                         {
                             ps.ProductID,
                             ps.ProductSpecificationOrder,
                             ps.ProductSpecificationHeader,
                             psa.AttributeKey,
                             psa.AttributeValue
                         };
            var distinctHeader = result.
                Select(p => p.ProductSpecificationHeader).Distinct();
            List<ProductSpecificationDetails> productSpecDetails = new List<ProductSpecificationDetails>();
            foreach (var item in distinctHeader)
            {
                ProductSpecificationDetails productSpecDetailObject = new ProductSpecificationDetails();
                productSpecDetailObject.ProductSpecHeading = item;
                productSpecDetailObject.ProductConfigurationDetails = (from attr in result where attr.ProductSpecificationHeader.Equals(item) select new ProductSubConfigurationDetails { SubHead = attr.AttributeKey, SubSpec = attr.AttributeValue }).ToList<ProductSubConfigurationDetails>();
                productSpecDetails.Add(productSpecDetailObject);
            }
            ProductSpecificationViewModel productSpecificationViewModel = new ProductSpecificationViewModel();
            productSpecificationViewModel.ProductID = ProductID;
            productSpecificationViewModel.lstProductSpecificationDetails = productSpecDetails;
            CombinedProductSpecificationViewModel combinedProductSpecificationViewModel = new CombinedProductSpecificationViewModel();
            combinedProductSpecificationViewModel.Product = repository.Products.FirstOrDefault(p => p.ProductID == ProductID);
            combinedProductSpecificationViewModel.ProductSpecificationViewModel = productSpecificationViewModel;
            return combinedProductSpecificationViewModel;
        }
        [HttpGet]
        public PartialViewResult _CustomerReviewWithForm(int customerReviewID = 0)
        {
            if(customerReviewID == 0)
            {
                return PartialView("Partial/General/_CustomerReviewForm", new CustomerReview());
            }
            else
            {
                CustomerReview customerReview = repository.CustomerReviews.FirstOrDefault(p => p.CustomerReviewID == customerReviewID);
                return PartialView("Partial/General/_CustomerReviewForm", customerReview);
            }
        }
        [HttpPost]
        public ActionResult _CustomerReviewWithForm(CustomerReview customerReview)
        {
            if(ModelState.IsValid)
            {
                repository.SaveCustomerReview(customerReview);
            }
            else
            {
                ModelState.AddModelError("Binding Error","Binding not acheived properly");
            }
            return Redirect(Request.Url.PathAndQuery.ToString());
        }
        public PartialViewResult _CustomerReviewForDisplay(int ProductID = 0)
        {
            if(ProductID == 0)
            {
                return PartialView("Partial/General/_CustomerReviewDisplay",null);
            }
            else
            {
                List<CustomerReview> lstCustomerReviews = (repository.CustomerReviews.Where(p => p.ProductID == ProductID)).ToList<CustomerReview>();
                return PartialView("Partial/General/_CustomerReviewDisplay", lstCustomerReviews);
            }
        }
    }
}