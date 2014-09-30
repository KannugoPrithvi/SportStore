using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public int CategoryID { get; set; }
        public int ProductID { get; set; }
        public int ProductCategoryOrder { get; set; }
        public string Group { get; set; }

        //public virtual Category Category { get; set; }
        //public virtual Product Product { get; set; }
    }
}
