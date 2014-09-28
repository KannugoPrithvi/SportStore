using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductRating
    {
        public int ProductRatingID { get; set; }
        public int ProductID { get; set; }
        public string ProductRatingDescription { get; set; }
        public byte AverageProductRating { get; set; }

        public virtual Product Product { get; set; }
    }
}
