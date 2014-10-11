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
        public void SaveCategories(Category category)
        {
            if(category.CategoryID ==0)
            {
                context.Category.Add(category);
            }
            else
            {
                Category dbEntry = context.Category.Find(category.CategoryID);
                if(dbEntry != null)
                {
                    dbEntry.Code = category.Code;
                    dbEntry.Name = category.Name;
                    dbEntry.Keywords = category.Keywords;
                    dbEntry.Description = category.Description;
                    dbEntry.IsActive = category.IsActive;
                    dbEntry.Header = category.Header;
                    dbEntry.Footer = category.Footer;
                    dbEntry.ParentCategory = category.ParentCategory;
                    dbEntry.CategoryOrder = category.CategoryOrder;
                }
            }
            context.SaveChanges();
        }
        public Category DeleteCategories(int categoryID)
        {
            Category dbEntry = context.Category.Find(categoryID);
            if(dbEntry !=null)
            {
                context.Category.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        //ProductCategories related CRUD operations
        public IEnumerable<ProductCategory> ProductCategories
        {
            get { return context.ProductCategory; }
        }

        public void SaveImages(ProductCategory productCategory)
        {
            if(productCategory.ProductCategoryID == 0)
            {
                context.ProductCategory.Add(productCategory);
            }
            else
            {
                ProductCategory dbEntry = context.ProductCategory.Find(productCategory.ProductCategoryID);
                if(dbEntry != null)
                {
                    dbEntry.CategoryID = productCategory.CategoryID;
                    dbEntry.ProductID = productCategory.ProductID;
                    dbEntry.ProductCategoryOrder = productCategory.ProductCategoryOrder;
                }
            }
            context.SaveChanges();
        }
        public ProductCategory DeleteProductCategory(int productCategoryID)
        {
            ProductCategory dbEntry = context.ProductCategory.Find(productCategoryID);
            if(dbEntry != null)
            {
                context.ProductCategory.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        //Images related CRUD operations
        public IEnumerable<Image> Images
        {
            get { return context.Image; }
        }

        public void SaveImages(Image image)
        {
            if(image.ImageID == 0)
            {
                context.Image.Add(image);
            }
            else
            {
                Image dbEntry = context.Image.Find(image.ImageID);
                if(dbEntry != null)
                {
                    dbEntry.ProductID = image.ProductID;
                    dbEntry.ImageDescription = image.ImageDescription;
                    dbEntry.SmallImage = image.SmallImage;
                    dbEntry.MediumImage = image.MediumImage;
                    dbEntry.LargeImage = image.LargeImage;
                    dbEntry.ExtraImage0 = image.ExtraImage0;
                    dbEntry.ExtraImage1 = image.ExtraImage1;
                    dbEntry.ExtraImage2 = image.ExtraImage2;
                }
            }
            context.SaveChanges();
        }

        public Image DeleteImage(int imageID)
        {
            Image dbEntry = context.Image.Find(imageID);
            if(dbEntry != null)
            {
                context.Image.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
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
            context.SaveChanges();
        }
        public ProductSpecification DeleteProductSpecification(int productSpecificationID)
        {
            ProductSpecification dbEntry = context.ProductSpecification.Find(productSpecificationID);
            if (dbEntry != null)
            {
                context.ProductSpecification.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
