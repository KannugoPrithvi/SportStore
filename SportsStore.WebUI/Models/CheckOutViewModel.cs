using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class
      CheckOutViewModel
    {
        public CustomerDetails BillingAddressDetails { get; set; }
        public CustomerDetails ShippingAddressDetails { get; set; }
        public bool IsShippingAddressChecked { get; set; }
        public String OrderNotes { get; set; }
        public String PaymentMode { get; set; }
    }
    public class CustomerDetails
    {
        public String Country { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String ZipCode { get; set; }
        public String TownCity { get; set; }
        public String StateProvince { get; set; }
        public String Company { get; set; }
        public String Phone { get; set; }
    }
}