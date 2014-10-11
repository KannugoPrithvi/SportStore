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
        public int ShippingMethodID { get; set; }
        public string Delivered { get; set; }
        public string Status { get; set; }
        public string StatusDetails { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
