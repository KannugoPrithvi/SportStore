using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class CustomerReview
    {
        public int CustomerReviewID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string Author { get; set; }
        public string ReviewSubject { get; set; }
        public string ReviewText { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<int> IsHelpfulYes { get; set; }
        public Nullable<int> IsHelpfulNo { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
