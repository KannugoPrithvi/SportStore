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
        public int ProductSpecificationOrder { get; set; }
        public string ProductSpecificationHeader { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }
    }
}
