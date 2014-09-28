using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class OrderItemAttribute
    {
        public int OrderItemAttributeID { get; set; }
        public Nullable<int> OrderItemID { get; set; }
        public Nullable<int> AttributeID { get; set; }
        public Nullable<int> OptionID { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Option Option { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}
