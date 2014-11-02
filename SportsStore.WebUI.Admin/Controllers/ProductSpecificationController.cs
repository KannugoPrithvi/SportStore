using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

//This file needs code reorganize
namespace SportsStore.WebUI.Admin.Controllers
{
    public class ProductSpecificationController : Controller
    {
        IProductRepository repository;
        XmlWriterSettings settings = null;        

        public ProductSpecificationController(IProductRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "ProductAdmin");
        }

        [HttpGet]
        public ActionResult Edit(int ProductID = 0)
        {
            ProductSpecification productSpecification = repository.ProductSpecifications.FirstOrDefault(p => p.ProductID == ProductID);
            ProductSpecificationViewModel productSpecViewModel = new ProductSpecificationViewModel();
            if(productSpecification != null)
            {
                productSpecViewModel.ProductID = productSpecification.ProductID;
                productSpecViewModel.lstProductSpecificationDetails = ConvertXMLToObject(productSpecification.ProductSpecificationInformation);
            }
            else
            {
                productSpecViewModel.ProductID = ProductID;
                productSpecViewModel.lstProductSpecificationDetails = new List<ProductSpecificationDetails> { new ProductSpecificationDetails { ProductSpecHeading = "General Specification", ProductSpecOrder = 0, ProductConfigurationDetails = GetConfigurationList() } };
            }
                     
            return View("ProductSpecificationList", productSpecViewModel);

        }

        [HttpPost]
        public ActionResult Edit(ProductSpecificationViewModel productSpecificationViewModel)
        {
            //Need to write product Specification write operation
            if (productSpecificationViewModel != null && ModelState.IsValid)
            {
                var request = Request.Form;
                String XMLForm = ConvertObjectToXML(productSpecificationViewModel);
                //repository.ProductSpecifications
                ProductSpecification dbEntry = new ProductSpecification {
                    ProductID=productSpecificationViewModel.ProductID,
                    ProductSpecificationInformation = XMLForm                
                };
                repository.SaveProductSpecification(dbEntry);
                TempData["message"] = string.Format("Product Specification for {0} has been saved",productSpecificationViewModel.ProductID.ToString());
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
            settings = new XmlWriterSettings();
            StringWriter writer = new StringWriter();
            settings.OmitXmlDeclaration = true;
            settings.Indent = false;
            settings.NewLineHandling = NewLineHandling.None;
            writer.NewLine = ""; 
            XmlWriter xmlwriter = XmlWriter.Create(writer, settings);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer MySerializer = new XmlSerializer(productSpecificationViewModel.GetType());        
            MySerializer.Serialize(writer, productSpecificationViewModel);
            return writer.ToString();
        }

        private List<ProductSpecificationDetails> ConvertXMLToObject(String Xml)
        {
            
            return null;
        }
              
    }
}