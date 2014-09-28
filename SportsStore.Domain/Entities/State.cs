using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class State
    {
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int StateOrder { get; set; }
        public bool IsActive { get; set; }
        public string Group { get; set; }

        public virtual ICollection<BasicTaxRate> BasicTaxRates { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
