using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Entities;
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<AdministratorRole> AdministratorRoles { get; set; }
        public virtual DbSet<SportsStore.Domain.Entities.Attribute> Attributes { get; set; }
        public virtual DbSet<BasicTaxRate> BasicTaxRates { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategorySetting> CategorySettings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerReview> CustomerReviews { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DiscountRange> DiscountRanges { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDelivery> OrderDeliveries { get; set; }
        public virtual DbSet<OrderDiscount> OrderDiscounts { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderItemAttribute> OrderItemAttributes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductRating> ProductRatings { get; set; }
        public virtual DbSet<ProductSetting> ProductSettings { get; set; }
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public virtual DbSet<RelatedProduct> RelatedProducts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SalesHistory> SalesHistories { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }
        public virtual DbSet<ShippingRate> ShippingRates { get; set; }
        public virtual DbSet<Sku> Skus { get; set; }
        public virtual DbSet<SkuDiscount> SkuDiscounts { get; set; }
        public virtual DbSet<State> States { get; set; }

    }
}
