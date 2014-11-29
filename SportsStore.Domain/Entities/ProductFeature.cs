using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductFeature
    {
        public int ProductFeatureID { get; set; }
        public int ProductID { get; set; }
        public string ProductFeatureHeader { get; set; }
        public string ProductFeatureBody { get; set; }
        public virtual Product Product { get; set; }
    }
}
