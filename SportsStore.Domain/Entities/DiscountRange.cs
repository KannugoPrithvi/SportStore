using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class DiscountRange
    {
        public int DiscountRangeID { get; set; }
        public int DiscountID { get; set; }
        public decimal Floor { get; set; }
        public decimal Ceiling { get; set; }
        public string RewardType { get; set; }
        public decimal Reward { get; set; }
        public bool IsActive { get; set; }
        public string Group { get; set; }

        public virtual Discount Discount { get; set; }
    }
}
