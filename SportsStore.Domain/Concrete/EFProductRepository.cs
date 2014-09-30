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
        public IEnumerable<Product> Products
        {
            get { return context.Product; }
        }

        public IEnumerable<Category> Categories
        {
            get { return context.Category; }
        }

        public IEnumerable<ProductCategory> ProductCategories
        {
            get { return context.ProductCategory; }
        }

        public IEnumerable<Image> Images
        {
            get { return context.Image; }
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
    }
}
