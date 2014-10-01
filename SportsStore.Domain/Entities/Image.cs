using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Image
    {
        public int ImageID { get; set; }
        public Nullable<int> ProductID { get; set; }        
        public string ImageDescription { get; set; }
        public string SmallImage { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }
        public string ExtraImage0 { get; set; }
        public string ExtraImage1 { get; set; }
        public string ExtraImage2 { get; set; }

       
        public virtual Product Product { get; set; }
    }
}
