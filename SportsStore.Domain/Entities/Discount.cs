using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string UsersAppliesType { get; set; }
        public string UsersAppliesValue { get; set; }
        public string ItemsAppliesTypes { get; set; }
        public string ItemsAppliesValue { get; set; }
        public string RewardType { get; set; }
        public Nullable<decimal> Reward { get; set; }
        public string CouponCode { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public Nullable<int> TimesUsed { get; set; }
        public Nullable<int> MaxTimesUsed { get; set; }
        public bool IsTimesPerCustomer { get; set; }
        public int DiscountOrder { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Group { get; set; }

        public virtual ICollection<DiscountRange> DiscountRanges { get; set; }
        public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; }
        public virtual ICollection<SalesHistory> SalesHistories { get; set; }
        public virtual ICollection<SkuDiscount> SkuDiscounts { get; set; }
    }
}
