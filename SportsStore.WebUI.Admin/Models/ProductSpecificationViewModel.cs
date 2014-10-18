using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SportsStore.WebUI.Models
{
    //Details which are shown under each table in key value pairs
    public class ProductSubConfigurationDetails
    {
        public string SubHead { get; set; }
        public string SubSpec { get; set; }
    }
    //Combination of one specification table
    public class ProductSpecificationDetails
    {
        public int ProductSpecOrder { get; set; }
        public string ProductSpecHeading { get; set; }
        [XmlArray]
        public List<ProductSubConfigurationDetails> ProductConfDetails { get; set; }
    }   

}