using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int OrderDeliveryID { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }

        public virtual Order Order { get; set; }
        public virtual OrderDelivery OrderDelivery { get; set; }
        public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderItemAttribute> OrderItemAttributes { get; set; }
    }
}
