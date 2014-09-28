using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int PaymentTypeID { get; set; }
        public string Status { get; set; }
        public int OrderID { get; set; }
        public string ProcessorClassName { get; set; }
        public string ValueFieldLabels { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public string Value7 { get; set; }
        public string Value8 { get; set; }
        public string Value9 { get; set; }
        public string Group { get; set; }

        public virtual Order Order { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
