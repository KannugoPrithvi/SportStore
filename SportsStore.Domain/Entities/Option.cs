using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Option
    {
        public int OptionID { get; set; }
        public int AttributeID { get; set; }
        public string OptionCode { get; set; }
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public bool OptionIsActive { get; set; }
        public Nullable<decimal> OptionUnitCost { get; set; }
        public Nullable<decimal> OptionUnitPrice { get; set; }
        public Nullable<decimal> OptionAltPrice { get; set; }
        public Nullable<decimal> OptionWeight { get; set; }
        public string OptionSmallImage { get; set; }
        public string OptionLargeImage { get; set; }
        public int OptionOrder { get; set; }
        public string Group { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual ICollection<OrderItemAttribute> OrderItemAttributes { get; set; }
    }
}
