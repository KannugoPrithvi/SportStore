using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductAttribute
    {
        public int ProductAttributeID { get; set; }
        public int ProductID { get; set; }
        public int AttributeID { get; set; }
        public int ProductAttributeOrder { get; set; }
        public string Group { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Product Product { get; set; }
    }
}
