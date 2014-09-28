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
        public string AttributeCode { get; set; }
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }
        public bool AttributeIsActive { get; set; }
        public string AttributeType { get; set; }
        public Nullable<decimal> AttributeUnitCost { get; set; }
        public Nullable<decimal> AttributeUnitPrice { get; set; }
        public Nullable<decimal> AttributeAltPrice { get; set; }
        public Nullable<decimal> AttributeWeight { get; set; }
        public string AttributeSmallImage { get; set; }
        public string AttributeLargeImage { get; set; }
        public Nullable<int> DefaultOptionID { get; set; }
        public bool AttributeIsRequired { get; set; }
        public int AttributeOrder { get; set; }
        public string Group { get; set; }

        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<OrderItemAttribute> OrderItemAttributes { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
