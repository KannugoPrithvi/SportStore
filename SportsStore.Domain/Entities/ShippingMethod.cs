using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ShippingMethod
    {
        public int ShippingMethodID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Minimum { get; set; }
        public decimal Base { get; set; }
        public string MethodType { get; set; }
        public bool IsActive { get; set; }
        public string Group { get; set; }

        public virtual ICollection<ShippingRate> ShippingRates { get; set; }
    }
}
