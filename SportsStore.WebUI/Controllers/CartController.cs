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
        public RedirectToRouteResult UpdateCart(Cart cart, string returnUrl, List<ProductCartList> lstProductCartList)
        {
            if(lstProductCartList != null || lstProductCartList.Count != 0)
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

        public ViewResult Checkout()
        {
            IEnumerable<SelectListItem> lstOfCountries = new List<SelectListItem>
            {
                new SelectListItem{Text="India",Value="IN"},
                new SelectListItem{Text="China",Value="CN"},
                new SelectListItem{Text="USA",Value="USA"},
                new SelectListItem{Text="Russia",Value="RU"},
                new SelectListItem{Text="Britain",Value="UK"},
                new SelectListItem{Text="France",Value="FRN"},
                new SelectListItem{Text="Vietnam",Value="VN"},

            };
            ViewData["Countries"] = lstOfCountries;
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
        [HttpPost]
        public ActionResult Checkout(Cart cart,CheckOutViewModel checkOutViewModel)
        {

            var request = Request.Form;
            return null;
        }
    }
}