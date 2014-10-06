using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductSpecification
    {
        public int ProductSpecificationID { get; set; }
        public int ProductID { get; set; }
        public int SkuID { get; set; }
        public string ProductSpecificationInformation { get; set; }
        public string Group { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sku Sku { get; set; }
    }
}
