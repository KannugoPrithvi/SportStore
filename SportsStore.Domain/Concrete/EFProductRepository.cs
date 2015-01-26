using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Data.SqlClient;

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

        //Attribute related CRUD operations
        public IEnumerable<SportsStore.Domain.Entities.Attribute> Attributes
        {
            get { return context.Attribute; }
        }
        public void SaveAttribute(SportsStore.Domain.Entities.Attribute attribute)
        {
            if (attribute.AttributeID == 0)
            {
                context.Attribute.Add(attribute);
            }
            else
            {
                SportsStore.Domain.Entities.Attribute dbEntry = context.Attribute.Find(attribute.AttributeID);
                if (dbEntry != null)
                {
                    dbEntry.ProductID = attribute.ProductID;
                    dbEntry.AttributeType = attribute.AttributeType;
                    dbEntry.AttributeValue = attribute.AttributeValue;
                    dbEntry.AttributeDescription = attribute.AttributeDescription;
                }                 
            }
            context.SaveChanges();
        }
        public SportsStore.Domain.Entities.Attribute DeleteAttribute(int attributeID)
        {
            SportsStore.Domain.Entities.Attribute dbEntry = context.Attribute.Find(attributeID);
            if (dbEntry != null)
            {
                context.Attribute.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //Categories related CRUD operations
        public IEnumerable<Category> Categories
        {
            get { return context.Category; }
        }
        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                context.Category.Add(category);
            }
            else
            {
                Category dbEntry = context.Category.Find(category.CategoryID);
                if (dbEntry != null)
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
        public Category DeleteCategory(int categoryID)
        {
            Category dbEntry = context.Category.Find(categoryID);
            if (dbEntry != null)
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

        public void SaveProductCategory(ProductCategory productCategory)
        {
            try
            {
                if (productCategory != null)
                {
                    context.ProductCategory.Add(productCategory);
                    context.SaveChanges();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ProductCategory DeleteProductCategory(ProductCategory productCategory)
        {
            try
            {
                if (productCategory != null)
                {
                    ProductCategory dbEntry = context.ProductCategory.FirstOrDefault(p => p.CategoryID == productCategory.CategoryID && p.ProductID == productCategory.ProductID);
                    context.ProductCategory.Remove(dbEntry);
                    context.SaveChanges();
                    return productCategory;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Images related CRUD operations
        public IEnumerable<Image> Images
        {
            get { return context.Image; }
        }

        public void SaveImage(Image image)
        {
            if (image.ImageID == 0)
            {
                context.Image.Add(image);
            }
            else
            {
                Image dbEntry = context.Image.Find(image.ImageID);
                if (dbEntry != null)
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
            if (dbEntry != null)
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
            if (productSpecification.ProductSpecificationID == 0)
            {
                context.ProductSpecification.Add(productSpecification);
            }
            else
            {
                ProductSpecification dbEntry = context.ProductSpecification.Find(productSpecification.ProductSpecificationID);
                if (dbEntry != null)
                {
                    dbEntry.ProductID = productSpecification.ProductID;
                    dbEntry.ProductSpecificationOrder = productSpecification.ProductSpecificationOrder;
                    dbEntry.ProductSpecificationHeader = productSpecification.ProductSpecificationHeader;
                    if (dbEntry.ProductSpecificationAttributes != null)
                    {
                        foreach (var item in productSpecification.ProductSpecificationAttributes)
                        {
                            SaveProductSpecificationAttribute(item);
                        }
                    }
                    else
                    {
                        dbEntry.ProductSpecificationAttributes = productSpecification.ProductSpecificationAttributes;
                    }
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

        public void DeleteProductSpecificationByProductID(int productID)
        {
            if (productID != 0)
            {
                var deleteList = context.ProductSpecification.Where(p => p.ProductID == productID);
                foreach (var item in deleteList)
                {
                    context.ProductSpecification.Remove(item);
                }
                context.SaveChanges();
            }
        }

        //ProductFeatures related CRUD operations
        public IEnumerable<ProductFeature> ProductFeatures
        {
            get { return context.ProductFeature; }
        }

        public void SaveProductFeature(ProductFeature productFeature)
        {

            if (productFeature.ProductFeatureID == 0)
            {
                context.ProductFeature.Add(productFeature);
            }
            else
            {
                ProductFeature dbEntry = context.ProductFeature.Find(productFeature.ProductFeatureID);
                if (dbEntry != null)
                {
                    dbEntry.ProductID = productFeature.ProductID;
                    dbEntry.ProductFeatureHeader = productFeature.ProductFeatureHeader;
                    dbEntry.ProductFeatureBody = productFeature.ProductFeatureBody;
                }
            }
            context.SaveChanges();
        }

        public ProductFeature DeleteProductFeature(int productFeatureID)
        {
            ProductFeature dbEntry = context.ProductFeature.Find(productFeatureID);
            if(dbEntry != null)
            {
                context.ProductFeature.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }













        //ProductSpecificationAttributes related CRUD operations
        public IEnumerable<ProductSpecificationAttribute> ProductSpecificationAttributes
        {
            get { return context.ProductSpecificationAttribute; }
        }
        public void SaveProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            if (productSpecificationAttribute.ProductSpecificationAttributeID == 0)
            {
                context.ProductSpecificationAttribute.Add(productSpecificationAttribute);
            }
            else
            {
                ProductSpecificationAttribute dbEntry = context.ProductSpecificationAttribute.Find(productSpecificationAttribute.ProductSpecificationAttributeID);
                if (dbEntry != null)
                {
                    dbEntry.ProductSpecificationID = productSpecificationAttribute.ProductSpecificationID;
                    dbEntry.AttributeKey = productSpecificationAttribute.AttributeKey;
                    dbEntry.AttributeValue = productSpecificationAttribute.AttributeValue;
                }
            }
            context.SaveChanges();
        }
        public ProductSpecificationAttribute DeleteProductSpecificationAttribute(int productSpecificationAttributeID)
        {
            ProductSpecificationAttribute dbEntry = context.ProductSpecificationAttribute.Find(productSpecificationAttributeID);
            if (dbEntry != null)
            {
                context.ProductSpecificationAttribute.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //State related CRUD operations
        public IEnumerable<State> States
        {
            get { return context.State; }
        }
        public void SaveState(State state)
        {
            if (state.StateID == 0)
            {
                context.State.Add(state);
            }
            else
            {
                State dbEntry = context.State.Find(state.StateID);
                if (dbEntry != null)
                {
                    dbEntry.CountryID = state.CountryID;
                    dbEntry.Name = state.Name;
                    dbEntry.Code = state.Code;
                }
            }
            context.SaveChanges();
        }

        public State DeleteState(int stateID)
        {
            State dbEntry = context.State.Find(stateID);
            if (dbEntry != null)
            {
                context.State.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }



        //RelatedProduct related CRUD operations
        public IEnumerable<RelatedProduct> RelatedProducts
        {
            get { return context.RelatedProduct; }
        }
        public void SaveRelatedProduct(RelatedProduct relatedProduct)
        {
            if (relatedProduct.RelatedProductID == 0)
            {
                context.RelatedProduct.Add(relatedProduct);
            }
            else
            {
                RelatedProduct dbEntry = context.RelatedProduct.Find(relatedProduct.RelatedProductID);
                if (dbEntry != null)
                {
                    dbEntry.ParentProductID = relatedProduct.RelatedProductID;
                    dbEntry.ProductID = relatedProduct.ProductID;
                    dbEntry.RelatedType = relatedProduct.RelatedType;
                    dbEntry.RelatedProductOrder = relatedProduct.RelatedProductOrder;
                }
            }
            context.SaveChanges();
        }

        public RelatedProduct DeleteRelatedProduct(int relatedProductID)
        {
            RelatedProduct dbEntry = context.RelatedProduct.Find(relatedProductID);
            if (dbEntry != null)
            {
                context.RelatedProduct.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }



        //ProductRating related CRUD operations
        public IEnumerable<ProductRating> ProductRatings
        {
            get { return context.ProductRating; }
        }
        public void SaveProductRating(ProductRating productRating)
        {
            if (productRating.ProductRatingID == 0)
            {
                context.ProductRating.Add(productRating);
            }
            else
            {
                ProductRating dbEntry = context.ProductRating.Find(productRating.ProductRatingID);
                if (dbEntry != null)
                {
                    dbEntry.ProductID = productRating.ProductID;
                    dbEntry.ProductRatingDescription = productRating.ProductRatingDescription;
                    dbEntry.AverageProductRating = productRating.AverageProductRating;
                }
            }
            context.SaveChanges();
        }

        public ProductRating DeleteProductRating(int productRatingID)
        {
            ProductRating dbEntry = context.ProductRating.Find(productRatingID);
            if (dbEntry != null)
            {
                context.ProductRating.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //City related CRUD operations
        public IEnumerable<City> Cities
        {
            get { return context.City; }
        }
        public void SaveCity(City city)
        {
            if (city.CityID == 0)
            {
                context.City.Add(city);
            }
            else
            {
                City dbEntry = context.City.Find(city.CityID);
                if (dbEntry != null)
                {
                    dbEntry.StateID = city.StateID;
                    dbEntry.Name = city.Name;
                    dbEntry.Code = city.Code;
                }
            }
            context.SaveChanges();
        }

        public City DeleteCity(int cityID)
        {
            City dbEntry = context.City.Find(cityID);
            if (dbEntry != null)
            {
                context.City.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        //Country related CRUD operations
        public IEnumerable<Country> Countries
        {
            get { return context.Country; }
        }
        public void SaveCountry(Country country)
        {
            if (country.CountryID == 0)
            {
                context.Country.Add(country);
            }
            else
            {
                Country dbEntry = context.Country.Find(country.CountryID);
                if (dbEntry != null)
                {
                    dbEntry.Name = country.Name;
                    dbEntry.Code = country.Code;
                }
            }
            context.SaveChanges();
        }

        public Country DeleteCountry(int countryID)
        {
            Country dbEntry = context.Country.Find(countryID);
            if (dbEntry != null)
            {
                context.Country.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        //Customer related CRUD operations
        public IEnumerable<Customer> Customers
        {
            get { return context.Customer; }
        }
        public void SaveCustomer(Customer customer)
        {
            if (customer.CustomerID == 0)
            {
                context.Customer.Add(customer);
            }
            else
            {
                Customer dbEntry = context.Customer.Find(customer.CustomerID);
                if (dbEntry != null)
                {
                    dbEntry.UserName = customer.UserName;
                    dbEntry.Password = customer.Password;
                    dbEntry.Email = customer.Email;
                    dbEntry.CreatedDate = customer.CreatedDate;
                    dbEntry.LastLogin = customer.LastLogin;
                    dbEntry.Status = customer.Status;
                    dbEntry.FirstName = customer.FirstName;
                    dbEntry.LastName = customer.LastName;
                    dbEntry.Organization = customer.Organization;
                }
            }
            context.SaveChanges();
        }

        public Customer DeleteCustomer(int customerID)
        {
            Customer dbEntry = context.Customer.Find(customerID);
            if (dbEntry != null)
            {
                context.Customer.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        //CustomerAddress related CRUD operations
        public IEnumerable<CustomerAddress> CustomerAddresses
        {
            get { return context.CustomerAddress; }
        }
        public void SaveCustomerAddress(CustomerAddress customerAddress)
        {
            if (customerAddress.CustomerAddressID == 0)
            {
                context.CustomerAddress.Add(customerAddress);
            }
            else
            {
                CustomerAddress dbEntry = context.CustomerAddress.Find(customerAddress.CustomerAddressID);
                if (dbEntry != null)
                {
                    dbEntry.CustomerID = customerAddress.CustomerID;
                    dbEntry.Name = customerAddress.Name;
                    dbEntry.Address = customerAddress.Address;
                    dbEntry.CityID = customerAddress.CityID;
                    dbEntry.StateID = customerAddress.StateID;
                    dbEntry.PostalCode = customerAddress.PostalCode;
                    dbEntry.CountryID = customerAddress.CountryID;
                    dbEntry.HomePhone = customerAddress.HomePhone;
                    dbEntry.WorkPhone = customerAddress.WorkPhone;
                    dbEntry.Notes = customerAddress.Notes;
                    dbEntry.IsBillingAddress = customerAddress.IsBillingAddress;
                    dbEntry.IsShippingAddress = customerAddress.IsShippingAddress;
                }
            }
            context.SaveChanges();
        }

        public CustomerAddress DeleteCustomerAddress(int customerAddressID)
        {
            CustomerAddress dbEntry = context.CustomerAddress.Find(customerAddressID);
            if (dbEntry != null)
            {
                context.CustomerAddress.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        //CustomerReview related CRUD operations
        public IEnumerable<CustomerReview> CustomerReviews
        {
            get { return context.CustomerReview; }
        }
        public void SaveCustomerReview(CustomerReview customerReview)
        {
            if (customerReview.CustomerReviewID == 0)
            {
                context.CustomerReview.Add(customerReview);
            }
            else
            {
                CustomerReview dbEntry = context.CustomerReview.Find(customerReview.CustomerReviewID);
                if (dbEntry != null)
                {
                    dbEntry.ProductID = customerReview.ProductID;
                    dbEntry.CustomerID = customerReview.CustomerID;
                    dbEntry.Author = customerReview.Author;
                    dbEntry.ReviewSubject = customerReview.ReviewSubject;
                    dbEntry.ReviewText = customerReview.ReviewText;
                    dbEntry.Rating = customerReview.Rating;
                    dbEntry.IsHelpfulYes = customerReview.IsHelpfulYes;
                    dbEntry.IsHelpfulNo = customerReview.IsHelpfulNo;
                    dbEntry.AddedDate = dbEntry.AddedDate;
                    dbEntry.ModifiedDate = dbEntry.ModifiedDate;
                }
            }
            context.SaveChanges();
        }

        public CustomerReview DeleteCustomerReview(int customerReviewID)
        {
            CustomerReview dbEntry = context.CustomerReview.Find(customerReviewID);
            if (dbEntry != null)
            {
                context.CustomerReview.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }




        //Order related CRUD operations
        public IEnumerable<Order> Orders
        {
            get { return context.Order; }
        }
        public void SaveOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                context.Order.Add(order);
            }
            else
            {
                Order dbEntry = context.Order.Find(order.OrderID);
                if (dbEntry != null)
                {
                    dbEntry.CustomerID = order.CustomerID;
                    dbEntry.OrderNumber = order.OrderNumber;
                    dbEntry.TrackingNumber = order.TrackingNumber;
                    dbEntry.Total = order.Total;
                    dbEntry.Shipping = order.Shipping;
                    dbEntry.Tax = order.Tax;
                    dbEntry.TaxableSubTotal = order.TaxableSubTotal;
                    dbEntry.SubTotal = order.SubTotal;
                    dbEntry.TotalWeight = order.TotalWeight;
                    dbEntry.Quantity = order.Quantity;
                    dbEntry.CreatedDate = order.CreatedDate;
                    dbEntry.LastModified = order.LastModified;
                    dbEntry.Completed = order.Completed;
                    dbEntry.Status = order.Status;
                    dbEntry.StatusDetails = order.StatusDetails;
                }
            }
            context.SaveChanges();
        }

        public Order DeleteOrder(int orderID)
        {
            Order dbEntry = context.Order.Find(orderID);
            if (dbEntry != null)
            {
                context.Order.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }



        //OrderDelivery related CRUD operations
        public IEnumerable<OrderDelivery> OrderDeliveries
        {
            get { return context.OrderDelivery; }
        }
        public void SaveOrderDelivery(OrderDelivery orderDelivery)
        {
            if (orderDelivery.OrderDeliveryID == 0)
            {
                context.OrderDelivery.Add(orderDelivery);
            }
            else
            {
                OrderDelivery dbEntry = context.OrderDelivery.Find(orderDelivery.OrderDeliveryID);
                if (dbEntry != null)
                {
                    dbEntry.OrderID = orderDelivery.OrderID;
                    dbEntry.ShippingMethodID = orderDelivery.ShippingMethodID;
                    dbEntry.Delivered = orderDelivery.Delivered;
                    dbEntry.Status = orderDelivery.Status;
                    dbEntry.StatusDetails = orderDelivery.StatusDetails;
                }
            }
            context.SaveChanges();
        }

        public OrderDelivery DeleteOrderDelivery(int orderDeliveryID)
        {
            OrderDelivery dbEntry = context.OrderDelivery.Find(orderDeliveryID);
            if (dbEntry != null)
            {
                context.OrderDelivery.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }




        //OrderItem related CRUD operations
        public IEnumerable<OrderItem> OrderItems
        {
            get { return context.OrderItem; }
        }
        public void SaveOrderItem(OrderItem orderItem)
        {
            if (orderItem.OrderItemID == 0)
            {
                context.OrderItem.Add(orderItem);
            }
            else
            {
                OrderItem dbEntry = context.OrderItem.Find(orderItem.OrderDeliveryID);
                if (dbEntry != null)
                {
                    dbEntry.OrderID = orderItem.OrderID;
                    dbEntry.OrderDeliveryID = orderItem.OrderDeliveryID;
                    dbEntry.Total = orderItem.Total;
                    dbEntry.Weight = orderItem.Weight;
                    dbEntry.Quantity = orderItem.Quantity;
                    dbEntry.ProductID = orderItem.ProductID;
                }
            }
            context.SaveChanges();
        }

        public OrderItem DeleteOrderItem(int orderItemID)
        {
            OrderItem dbEntry = context.OrderItem.Find(orderItemID);
            if (dbEntry != null)
            {
                context.OrderItem.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        //Administrator related CRUD operations
        public IEnumerable<Administrator> Administrators
        {
            get { return context.Administrator; }
        }
        public void SaveAdministrator(Administrator administrator)
        {
            if (administrator.AdministratorID == 0)
            {
                context.Administrator.Add(administrator);
            }
            else
            {
                Administrator dbEntry = context.Administrator.Find(administrator.AdministratorID);
                if (dbEntry != null)
                {
                    dbEntry.UserName = administrator.UserName;
                    dbEntry.Password = administrator.Password;
                    dbEntry.LastLogin = administrator.LastLogin;
                    dbEntry.IsActive = administrator.IsActive;
                }
            }
            context.SaveChanges();
        }

        public Administrator DeleteAdministrator(int administratorID)
        {
            Administrator dbEntry = context.Administrator.Find(administratorID);
            if (dbEntry != null)
            {
                context.Administrator.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        //AdministratorRole related CRUD operations
        public IEnumerable<AdministratorRole> AdministratorRoles
        {
            get { return context.AdministratorRole; }
        }
        public void SaveAdministratorRole(AdministratorRole administratorRole)
        {
            if (administratorRole.AdministratorRoleID == 0)
            {
                context.AdministratorRole.Add(administratorRole);
            }
            else
            {
                AdministratorRole dbEntry = context.AdministratorRole.Find(administratorRole.AdministratorRoleID);
                if (dbEntry != null)
                {
                    dbEntry.AdministratorID = administratorRole.AdministratorID;
                    dbEntry.RoleID = administratorRole.RoleID;
                }
            }
            context.SaveChanges();
        }

        public AdministratorRole DeleteAdministratorRole(int administratorRoleID)
        {
            AdministratorRole dbEntry = context.AdministratorRole.Find(administratorRoleID);
            if (dbEntry != null)
            {
                context.AdministratorRole.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        //Role related CRUD operations
        public IEnumerable<Role> Roles
        {
            get { return context.Role; }
        }
        public void SaveRole(Role role)
        {
            if (role.RoleID == 0)
            {
                context.Role.Add(role);
            }
            else
            {
                Role dbEntry = context.Role.Find(role.RoleID);
                if (dbEntry != null)
                {
                    dbEntry.Code = role.Code;
                    dbEntry.Name = role.Name;
                    dbEntry.Description = role.Description;
                }
            }
            context.SaveChanges();
        }

        public Role DeleteRole(int roleID)
        {
            Role dbEntry = context.Role.Find(roleID);
            if (dbEntry != null)
            {
                context.Role.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
