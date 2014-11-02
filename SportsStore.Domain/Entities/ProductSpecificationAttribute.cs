using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductSpecificationAttribute
    {
        public int ProductSpecificationAttributeID { get; set; }
        public int ProductSpecificationID { get; set; }
        public string AttributeKey { get; set; }
        public string AttributeValue { get; set; }

        public virtual ProductSpecification ProductSpecification { get; set; }
    }
}
