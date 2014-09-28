using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductSpecification
    {
        public int ProductSpecificationID { get; set; }
        public int ProductID { get; set; }
        public int SkuID { get; set; }
        public Nullable<int> ProductSpecificationOrder { get; set; }
        public string SpecificationHead { get; set; }
        public string SpecificationKey0 { get; set; }
        public string SpecificationValue0 { get; set; }
        public string SpecificationKey1 { get; set; }
        public string SpecificationValue1 { get; set; }
        public string SpecificationKey2 { get; set; }
        public string SpecificationValue2 { get; set; }
        public string SpecificationKey3 { get; set; }
        public string SpecificationValue3 { get; set; }
        public string SpecificationKey4 { get; set; }
        public string SpecificationValue4 { get; set; }
        public string SpecificationKey5 { get; set; }
        public string SpecificationValue5 { get; set; }
        public string SpecificationKey6 { get; set; }
        public string SpecificationValue6 { get; set; }
        public string SpecificationKey7 { get; set; }
        public string SpecificationValue7 { get; set; }
        public string SpecificationKey8 { get; set; }
        public string SpecificationValue8 { get; set; }
        public string SpecificationKey9 { get; set; }
        public string SpecificationValue9 { get; set; }
        public string Group { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sku Sku { get; set; }
    }
}
