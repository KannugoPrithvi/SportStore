using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class AuthenticatedCheckoutViewModel
    {
        public CustomerAddress BillingAddress;
        public CustomerAddress ShippingAddress;
        public bool IsShippingAddressChecked { get; set; }
        //public CheckoutPaymentInformation paymentInformation;
    }
    public class CheckoutPaymentInformation
    {
        public bool IsCreditCard { get; set; }
        public bool IsDebitCard { get; set; }
        public bool IsCOD { get; set; }
        public bool IsPayPal { get; set; }
    }

}