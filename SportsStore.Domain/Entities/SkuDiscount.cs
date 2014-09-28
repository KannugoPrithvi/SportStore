using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class SkuDiscount
    {
        public int SkuDiscountID { get; set; }
        public int SkuID { get; set; }
        public int DiscountID { get; set; }
        public string Group { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Sku Sku { get; set; }
    }
}
