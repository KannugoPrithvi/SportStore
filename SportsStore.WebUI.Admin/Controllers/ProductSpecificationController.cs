using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;

//This file needs code reorganize
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
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int productSpecificationID = 1)
        {
            ProductSpecification productSpecification = repository.ProductSpecifications.FirstOrDefault(p => p.ProductID == productSpecificationID);
            ProductSpecificationViewModel productSpecViewModel = new ProductSpecificationViewModel();
            var Products = from r in repository.Products select r;
            List<SelectListItem> lstProductDropDown = null;
            if (Products != null)
            {
                lstProductDropDown = new List<SelectListItem>();
                foreach (var item in Products)
                {
                    //if (productSpecification.ProductID == item.ProductID)
                    if (productSpecificationID == 1)
                    {
                        lstProductDropDown.Add(new SelectListItem { Text = item.Name, Value = item.ProductID.ToString(), Selected = true });
                    }
                    else
                    {
                        lstProductDropDown.Add(new SelectListItem { Text = item.Name, Value = item.ProductID.ToString(), Selected = false });
                    }
                }
                ViewBag.ProductDropDown = lstProductDropDown;
            }
            else
            {
                ViewBag.ProductDropDown = null;
            }


            //Code needs to be written for Skus,context code and DAL code,Abover 20 lines of code has to be written for the SKU
            List<ProductSpecificationDetails> prodSpecDetailsList = new List<ProductSpecificationDetails>();
            prodSpecDetailsList.Add(new ProductSpecificationDetails
            {
                ProductSpecHeading = "General Specification",
                ProductSpecOrder = 0,
                ProductConfigurationDetails = GetConfigurationList()

            });
            prodSpecDetailsList.Add(new ProductSpecificationDetails
            {
                ProductSpecHeading = "General Specification 1",
                ProductSpecOrder = 1,
                ProductConfigurationDetails = GetConfigurationList()

            });
            prodSpecDetailsList.Add(new ProductSpecificationDetails
            {
                ProductSpecHeading = "General Specification 2",
                ProductSpecOrder = 2,
                ProductConfigurationDetails = GetConfigurationList()

            });
            //productSpecViewModel.ProductID = productSpecification.ProductID == 0 ? 1 : productSpecification.ProductID;
            //productSpecViewModel.SkuID = productSpecification.SkuID;
            productSpecViewModel.ProductID = 1;
            productSpecViewModel.SkuID = 1;
            productSpecViewModel.lstProductSpecificationDetails = prodSpecDetailsList;
            productSpecViewModel.ProductSpecificationID = productSpecificationID;
            return View("ProductSpecificationList", productSpecViewModel);

        }

        [HttpPost]
        public ActionResult Edit(ProductSpecificationViewModel productSpecificationViewModel)
        {
            //Need to write product Specification write operation
            if (productSpecificationViewModel != null)
            {
                var request = Request.Form;
                String XMLForm = ConvertObjectToXML(productSpecificationViewModel);
                //repository.ProductSpecifications
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult NewSpecificationTable(int TableIndex = 0)
        {
            ProductSpecificationDetails prodSpecDetails = new ProductSpecificationDetails();
            prodSpecDetails.ProductSpecOrder = TableIndex;
            prodSpecDetails.ProductConfigurationDetails = GetConfigurationList();
            ViewBag.TableIndexNo = "SpecificationList_" + TableIndex;
            ViewBag.ButtonAddIndex = "btnAddRow_" + TableIndex;
            ViewBag.TableIndexNoJSID = "#" + ViewBag.TableIndexNo as String;
            ViewBag.ButtonAddIndexJSID = "#" + ViewBag.ButtonAddIndex as string;
            return PartialView("Partial/ProductSpecification", prodSpecDetails);
        }

        private List<ProductSubConfigurationDetails> GetConfigurationList()
        {
            List<ProductSubConfigurationDetails> configurationList = new List<ProductSubConfigurationDetails>();
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_1", SubSpec = "Name_Value_1" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_2", SubSpec = "Name_Value_2" });
            configurationList.Add(new ProductSubConfigurationDetails { SubHead = "Name_Key_3", SubSpec = "Name_Value_3" });

            return configurationList;
        }

        private string ConvertObjectToXML(ProductSpecificationViewModel productSpecificationViewModel)
        {
            StringWriter writer = new StringWriter();

            XmlSerializer x = new XmlSerializer(productSpecificationViewModel.GetType());
            x.Serialize(writer, productSpecificationViewModel);
            return writer.ToString();
        }

        private string ConvertXMLToObject(String Xml)
        {
            return null;
        }

        public string ConvertToXML()
        {
            return null;
        }
    }
}