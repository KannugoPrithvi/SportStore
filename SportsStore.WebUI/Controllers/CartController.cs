using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IProductRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        //Cart object is now supplied by model binder
        //public Cart GetCart()
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if (product != null)
            {
                cart.AddItem(product, 1, 0);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult DeleteAddress(string returnURL, int CustomerAddressID = 0)
        {
            if (CustomerAddressID != 0)
            {
                repository.DeleteCustomerAddress(CustomerAddressID);
                return RedirectToAction("Checkout", new { returnURL });
            }
            else
            {
                return RedirectToRoute(new { controller = "Product", action = "Index" });
            }
        }
        [HttpGet]
        public ActionResult CreateEditAddress(int CustomerAddressID = 0)
        {
            var lstOfCountries = repository.Countries.ToList<Country>();
            List<SelectListItem> selectCountryList = new List<SelectListItem>();
            foreach (var item in lstOfCountries)
            {
                if (item.States.Count > 0)
                {
                    selectCountryList.Add(new SelectListItem { Text = item.CountryName, Value = item.CountryID.ToString() });
                }
            }
            ViewData["Countries"] = selectCountryList;
            if (CustomerAddressID != 0)
            {
                CustomerAddress customerAddress = repository.CustomerAddresses.FirstOrDefault(p => p.CustomerAddressID == CustomerAddressID);
                selectCountryList.FirstOrDefault(p => p.Value == customerAddress.CountryID.ToString()).Selected = true;
                return View("Address", customerAddress);
            }
            else
            {
                return View("Address", new CustomerAddress { CustomerID = Convert.ToInt32(User.Identity.GetUserId()) });
            }
        }
        [HttpPost]
        public RedirectToRouteResult CreateEditAddress(CustomerAddress customerAddress, string returnURL)
        {
            if (ModelState.IsValid && customerAddress != null)
            {
                repository.SaveCustomerAddress(customerAddress);
            }
            return RedirectToAction("Checkout", new { returnURL});
        }
        public RedirectToRouteResult UpdateCart(Cart cart, string returnUrl, List<ProductCartList> lstProductCartList)
        {
            if (lstProductCartList != null || lstProductCartList.Count != 0)
            {
                foreach (var item in lstProductCartList)
                {
                    Product product = repository.Products.Where(p => p.ProductID == item.ProductID).FirstOrDefault();
                    if (product != null)
                    {
                        cart.AddItem(product, item.Quantity, 1);
                    }
                }
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        [HttpGet]
        public ViewResult Checkout()
        {

            return View(new CheckOutViewModel());
        }
        //[HttpPost]
        //public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        //{
        //    if (cart.Lines.Count() == 0)
        //    {
        //        ModelState.AddModelError("", "Sorry your cart is empty!");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        orderProcessor.ProcessOrder(cart, shippingDetails);
        //        cart.Clear();
        //        return View("Completed");
        //    }
        //    else
        //    {
        //        return View(shippingDetails);
        //    }
        //}
        public PartialViewResult AuthenticatedAddressCheckoutForm(int CustomerID = 0)
        {
            if (CustomerID != 0)
            {
                var allCustomerAddresses = repository.CustomerAddresses.Where(p => p.CustomerID == CustomerID).ToList<CustomerAddress>();
                return PartialView("Partial/_AuthenticatedCheckoutForm", allCustomerAddresses);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Checkout(Cart cart, CheckOutViewModel checkOutViewModel)
        {
            return null;
            var request = Request.Form;
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    AccountController accountController = new AccountController();
                    CartUser user = new CartUser
                    {
                        FirstName = checkOutViewModel.BillingAddressDetails.FirstName,
                        LastName = checkOutViewModel.BillingAddressDetails.LastName,
                        Email = checkOutViewModel.BillingAddressDetails.Email,
                        UserName = checkOutViewModel.BillingAddressDetails.FirstName + " ," + checkOutViewModel.BillingAddressDetails.LastName,
                    };
                    if (checkOutViewModel.IsShippingAddressChecked == false)
                    {

                    }
                    else
                    {

                    }
                    orderProcessor.ProcessOrder(cart, new ShippingDetails());
                    cart.Clear();
                    return View("Completed");
                }
            }
            else
            {
                return View(checkOutViewModel);
            }
        }
        public JsonResult GetStates(int CountryID = 0)
        {
            if (CountryID != 0)
            {
                List<State> lstOfStates = repository.States.Where(p => p.CountryID == CountryID).OrderBy(p => p.StateName).ToList<State>();
                List<SelectListItem> selectStatesList = new List<SelectListItem>();
                foreach (var item in lstOfStates)
                {
                    selectStatesList.Add(new SelectListItem { Text = item.StateName, Value = item.StateID.ToString() });
                }
                return Json(new SelectList(selectStatesList, "Value", "Text"));
            }
            else
            {
                return null;
            }


        }
        public JsonResult GetCities(int StateID = 0)
        {
            if (StateID != 0)
            {
                List<City> lstOfCities = repository.Cities.Where(p => p.StateID == StateID).OrderBy(p => p.CityName).ToList<City>();
                List<SelectListItem> selectCitiesList = new List<SelectListItem>();
                foreach (var item in lstOfCities)
                {
                    selectCitiesList.Add(new SelectListItem { Text = item.CityName, Value = item.CityID.ToString() });
                }
                return Json(new SelectList(selectCitiesList, "Value", "Text"));
            }
            else
            {
                return null;
            }


        }

    }
}