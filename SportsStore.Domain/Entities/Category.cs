using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public Nullable<int> ParentCategory { get; set; }
        public int CategoryOrder { get; set; }
        public string Group { get; set; }

        public virtual ICollection<CategorySetting> CategorySettings { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<SalesHistory> SalesHistories { get; set; }
    }
}
