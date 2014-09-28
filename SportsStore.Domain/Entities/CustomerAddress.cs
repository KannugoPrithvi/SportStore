using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class CustomerAddress
    {
        public int CustomerAddressID { get; set; }
        public int CustomerID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string PostalCode { get; set; }
        public int CountryID { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternativeEmail { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }
        public string Notes { get; set; }
        public string Group { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<SalesHistory> SalesHistories { get; set; }
    }
}
