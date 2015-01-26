using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }       

        public virtual ICollection<BasicTaxRate> BasicTaxRates { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
