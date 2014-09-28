using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class BasicTaxRate
    {
        public int BasicTaxRateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public decimal Rate { get; set; }
        public bool IsActive { get; set; }
        public string Group { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}
