using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string UserName { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public string TrackingNumber { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Shipping { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> TaxableSubTotal { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> TotalWeight { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public string Completed { get; set; }
        public string Status { get; set; }
        public string StatusDetails { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; }
        public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
