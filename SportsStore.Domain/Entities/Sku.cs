using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Sku
    {
        public int SkuID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> AttributeID1 { get; set; }
        public Nullable<int> OptionID1 { get; set; }
        public Nullable<int> AttributeID2 { get; set; }
        public Nullable<int> OptionID2 { get; set; }
        public Nullable<int> AttributeID3 { get; set; }
        public Nullable<int> OptionID4 { get; set; }
        public Nullable<int> AttributeID5 { get; set; }
        public Nullable<int> OptionID5 { get; set; }
        public string SkuNumber { get; set; }
        public string SkuName { get; set; }
        public string SkuMessage { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public bool TrackInventory { get; set; }
        public int InventoryLevel { get; set; }
        public string Notes { get; set; }
        public string Group { get; set; }

        public virtual Product Product { get; set; }
        
        public virtual ICollection<SkuDiscount> SkuDiscounts { get; set; }
    }
}
