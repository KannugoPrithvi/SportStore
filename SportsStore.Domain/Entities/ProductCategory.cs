using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ProductCategory
    {
        
        [DisplayName("Category")]
        [Key]
        [Column(Order=2)]
        public int CategoryID { get; set; }
        
        [DisplayName("Product")]
        [Key]
        [Column(Order = 1)]
        public int ProductID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
