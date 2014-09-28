using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string Group { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<CustomerReview> CustomerReviews { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SalesHistory> SalesHistories { get; set; }
    }
}
