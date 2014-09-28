using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductSetting
    {
        public int ProductSettingID { get; set; }
        public int ProductID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ValueType { get; set; }
        public Nullable<int> IntegerValue { get; set; }
        public string SmallValue { get; set; }
        public string MediumValue { get; set; }
        public string TextValue { get; set; }
        public string Group { get; set; }

        public virtual Product Product { get; set; }
    }
}
