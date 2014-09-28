using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ShippingRate
    {
        public int ShippingRateID { get; set; }
        public int ShippingMethodID { get; set; }
        public decimal Floor { get; set; }
        public decimal Ceiling { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public string Group { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }
    }
}
