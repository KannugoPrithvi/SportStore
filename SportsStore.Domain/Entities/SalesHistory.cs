using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class SalesHistory
    {
        public int SalesHistoryID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> CustomerAddressID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> SalesAmount { get; set; }
        public Nullable<int> SalesReturns { get; set; }
        public Nullable<decimal> SalesCost { get; set; }
        public Nullable<int> DiscountID { get; set; }
        public Nullable<System.DateTime> SalesDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerAddress CustomerAddress { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual SalesHistory SalesHistory1 { get; set; }
        
    }
}
