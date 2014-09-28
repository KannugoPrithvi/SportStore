using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class PaymentType
    {
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; }
        public string PaymentTypeDescription { get; set; }
        public string PaymentTypeAttributes { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
