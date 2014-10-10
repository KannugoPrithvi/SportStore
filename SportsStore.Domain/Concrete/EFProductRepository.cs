using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        //Product related CRUD operations
        public IEnumerable<Product> Products
        {
            get { return context.Product; }
        }
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Product.Add(product);
            }
            else
            {
                Product dbEntry = context.Product.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Code = product.Code;
                    dbEntry.Name = product.Name;
                    dbEntry.Keywords = product.Keywords;
                    dbEntry.ShortDescription = product.ShortDescription;
                    dbEntry.Description = product.Description;
                    dbEntry.IsDiscontinued = product.IsDiscontinued;
                    dbEntry.InStock = product.InStock;
                    dbEntry.UnitCost = product.UnitCost;
                    dbEntry.UnitPrice = product.UnitPrice;
                    dbEntry.AltPrice = product.AltPrice;
                    dbEntry.Weight = product.Weight;
                    dbEntry.Header = product.Header;
                    dbEntry.Footer = product.Footer;
                    dbEntry.IsTaxed = product.IsTaxed;
                    dbEntry.MaximumProductQuantity = product.MaximumProductQuantity;
                    dbEntry.ProductOrder = dbEntry.ProductOrder;
                }
            }
            context.SaveChanges();
        }


        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Product.Find(productID);
            if (dbEntry != null)
            {
                context.Product.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        //Categories related CRUD operations
        public IEnumerable<Category> Categories
        {
            get { return context.Category; }
        }
        //ProductCategories related CRUD operations
        public IEnumerable<ProductCategory> ProductCategories
        {
            get { return context.ProductCategory; }
        }
        //Images related CRUD operations
        public IEnumerable<Image> Images
        {
            get { return context.Image; }
        }
        //ProductSpecifications related CRUD operations
        public IEnumerable<ProductSpecification> ProductSpecifications
        {
            get { return context.ProductSpecification; }
        }
        public void SaveProductSpecification(ProductSpecification productSpecification)
        {
            if(productSpecification.ProductSpecificationID ==0)
            {
                context.ProductSpecification.Add(productSpecification);
            }
            else
            {
                ProductSpecification dbEntry = context.ProductSpecification.Find(productSpecification.ProductSpecificationID);
                if(dbEntry!=null)
                {
                    dbEntry.ProductID = productSpecification.ProductID;
                    dbEntry.SkuID = productSpecification.SkuID;
                    dbEntry.ProductSpecificationInformation = productSpecification.ProductSpecificationInformation;                    
                }
            }
        }
        public ProductSpecification DeleteProductSpecification(int productSpecificationID)
        {
            ProductSpecification dbEntry = context.ProductSpecification.Find(productSpecification.ProductSpecificationID);
            if (dbEntry != null)
            {
                context.ProductSpecification.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
