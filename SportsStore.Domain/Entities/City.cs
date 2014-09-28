using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class City
    {
        public int CityID { get; set; }
        public Nullable<int> StateID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<int> CityOrder { get; set; }
        public bool IsActive { get; set; }
        public string Group { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
