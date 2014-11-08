using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        //Products
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);

        //Categories
        IEnumerable<Category> Categories { get; }
        void SaveCategory(Category category);
        Category DeleteCategory(int categoryID);

        //ProductCatgories
        IEnumerable<ProductCategory> ProductCategories { get; }
        void SaveProductCategory(ProductCategory productCategory);
        ProductCategory DeleteProductCategory(int productCategoryID);

        //Images
        IEnumerable<Image> Images { get; }
        void SaveImage(Image image);
        Image DeleteImage(int imageID);

        //ProductSpecifications
        IEnumerable<ProductSpecification> ProductSpecifications { get; }
        void SaveProductSpecification(ProductSpecification productSpecification);
        ProductSpecification DeleteProductSpecification(int productSpecificationID);
        void DeleteProductSpecificationByProductID(int productID);

        //ProductSpecificationAttributes
        IEnumerable<ProductSpecificationAttribute> ProductSpecificationAttributes { get; }
        void SaveProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);
        ProductSpecificationAttribute DeleteProductSpecificationAttribute(int productSpecificationAttributeID);

        //States
        IEnumerable<State> States { get; }
        void SaveState(State state);
        State DeleteState(int stateID);

        //RelatedProduct
        IEnumerable<RelatedProduct> RelatedProducts { get; }
        void SaveRelatedProduct(RelatedProduct relatedProduct);
        RelatedProduct DeleteRelatedProduct(int relatedProductID);

        //ProductRating
        IEnumerable<ProductRating> ProductRatings { get; }
        void SaveProductRating(ProductRating productRating);
        ProductRating DeleteProductRating(int productRatingID);

        //City
        IEnumerable<City> Cities { get; }
        void SaveCity(City city);
        City DeleteCity(int cityID);

        //Country
        IEnumerable<Country> Countries { get; }
        void SaveCountry(Country country);
        Country DeleteCountry(int countryID);

        //Customer
        IEnumerable<Customer> Customers { get; }
        void SaveCustomer(Customer customer);
        Customer DeleteCustomer(int customerID);


        //CustomerAddress
        IEnumerable<CustomerAddress> CustomerAddresses { get; }
        void SaveCustomerAddress(CustomerAddress customerAddress);
        CustomerAddress DeleteCustomerAddress(int customerAddressID);


        //CustomerReview
        IEnumerable<CustomerReview> CustomerReviews { get; }
        void SaveCustomerReview(CustomerReview customerReview);
        CustomerReview DeleteCustomerReview(int customerReviewID);


        //Order
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
        Order DeleteOrder(int orderID);


        //OrderDelivery
        IEnumerable<OrderDelivery> OrderDeliveries { get; }
        void SaveOrderDelivery(OrderDelivery orderDelivery);
        OrderDelivery DeleteOrderDelivery(int orderDeliveryID);


        //OrderItem
        IEnumerable<OrderItem> OrderItems { get; }
        void SaveOrderItem(OrderItem orderItem);
        OrderItem DeleteOrderItem(int orderItemID);


        //Administrator
        IEnumerable<Administrator> Administrators { get; }
        void SaveAdministrator(Administrator administrator);
        Administrator DeleteAdministrator(int administratorID);


        //AdministratorRole
        IEnumerable<AdministratorRole> AdministratorRoles { get; }
        void SaveAdministratorRole(AdministratorRole administratorRole);
        AdministratorRole DeleteAdministratorRole(int administratorRoleID);


        //Role
        IEnumerable<Role> Roles { get; }
        void SaveRole(Role role);
        Role DeleteRole(int roleID);
        
    }
}
