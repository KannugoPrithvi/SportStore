using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class OrderAddress
    {
        public int OrderAddressID { get; set; }
        public int OrderID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsBillingAddress { get; set; }
        public Nullable<bool> IsShippingAddress { get; set; }

        public virtual Order Order { get; set; }
    }
}
