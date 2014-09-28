using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class OrderDelivery
    {
        public int OrderDeliveryID { get; set; }
        public int OrderID { get; set; }
        public string TrackingNumber { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Shipping { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> TaxableSubtotal { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string Delivered { get; set; }
        public string Status { get; set; }
        public string StatusDetails { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
