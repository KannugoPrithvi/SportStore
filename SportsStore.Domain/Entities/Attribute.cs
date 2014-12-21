using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Attribute
    {
        public int AttributeID { get; set; }
        public int ProductID { get; set; }
        public string AttributeType { get; set; }
        public string AttributeValue { get; set; }
        public string AttributeDescription { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<OrderItemAttribute> OrderItemAttributes { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        
    }
}
