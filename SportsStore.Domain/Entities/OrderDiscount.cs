using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class OrderDiscount
    {
        public int OrderDiscountID { get; set; }
        public int OrderID { get; set; }
        public Nullable<int> OrderItemID { get; set; }
        public Nullable<decimal> Total { get; set; }
        public int DiscountID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string UsersAppliesType { get; set; }
        public string UsersAppliesValue { get; set; }
        public string ItemsAppliesType { get; set; }
        public string ItemsAppliesValue { get; set; }
        public string RewardType { get; set; }
        public decimal Reward { get; set; }
        public string CouponCode { get; set; }
        public Nullable<decimal> Floor { get; set; }
        public Nullable<decimal> Ceiling { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Group { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}
