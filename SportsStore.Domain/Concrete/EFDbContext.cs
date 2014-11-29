using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<AdministratorRole> AdministratorRole { get; set; }
        public virtual DbSet<SportsStore.Domain.Entities.Attribute> Attribute { get; set; }
        public virtual DbSet<BasicTaxRate> BasicTaxRate { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategorySetting> CategorySetting { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<CustomerReview> CustomerReview { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<DiscountRange> DiscountRange { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDelivery> OrderDelivery { get; set; }
        public virtual DbSet<OrderDiscount> OrderDiscount { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderItemAttribute> OrderItemAttribute { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttribute { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductRating> ProductRating { get; set; }
        public virtual DbSet<ProductSetting> ProductSetting { get; set; }
        public virtual DbSet<ProductSpecification> ProductSpecification { get; set; }
        public virtual DbSet<ProductSpecificationAttribute> ProductSpecificationAttribute { get; set; }
        public virtual DbSet<ProductFeature> ProductFeature { get; set; }
        public virtual DbSet<RelatedProduct> RelatedProduct { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SalesHistory> SalesHistory { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethod { get; set; }
        public virtual DbSet<ShippingRate> ShippingRate { get; set; }
        public virtual DbSet<Sku> Sku { get; set; }
        public virtual DbSet<SkuDiscount> SkuDiscount { get; set; }
        public virtual DbSet<State> State { get; set; }

    }
}
