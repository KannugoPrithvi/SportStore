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
        public string CountryFIPS { get; set; }
        public string CountryISO { get; set; }
        public string CountryTLD { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<BasicTaxRate> BasicTaxRates { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
