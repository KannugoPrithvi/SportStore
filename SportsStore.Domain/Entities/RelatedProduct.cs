using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class RelatedProduct
    {
        public int RelatedProductID { get; set; }
        public int ParentProductID { get; set; }
        public int ProductID { get; set; }
        public string RelatedType { get; set; }
        public Nullable<int> RelatedProductOrder { get; set; }
        public string Group { get; set; }

        public virtual Product Product { get; set; }
        public virtual Product Product1 { get; set; }
    }
}
