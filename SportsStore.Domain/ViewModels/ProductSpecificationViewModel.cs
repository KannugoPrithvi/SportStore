using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SportsStore.Domain.ViewModels
{
    //Details which are shown under each table in key value pairs
    public class ProductSubConfigurationDetails
    {
        public int ProductSpecificationAttributeID{ get; set; }
        public int ProductSpecificationID { get; set; }
        public string SubHead { get; set; }
        public string SubSpec { get; set; }
    }
    //Combination of one specification table
    public class ProductSpecificationDetails
    {
        public int ProductSpecOrder { get; set; }
        public string ProductSpecHeading { get; set; }
        public int ProductSpecificationID { get; set; }
        public List<ProductSubConfigurationDetails> ProductConfigurationDetails { get; set; }
    }  
    [Serializable]
    public class ProductSpecificationViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public List<ProductSpecificationDetails> lstProductSpecificationDetails { get; set; }
    }

}