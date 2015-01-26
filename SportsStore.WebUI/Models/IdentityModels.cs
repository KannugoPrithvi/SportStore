using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class CartUser : IdentityUser<int,CartUserLogin,CartUserRole,CartUserClaim>,IUser<int>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CartUser,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? AccountCreatedDate { get; set; }
        public DateTime? LastAccessDate { get; set; }

    }
    public class CartRole: IdentityRole<int,CartUserRole>
    {
        public CartRole()
        {  }
        public CartRole(string name)
        {
            Name = name;
        }
    }
    public class CartUserRole : IdentityUserRole<int> { }
    public class CartUserClaim : IdentityUserClaim<int> { }
    public class CartUserLogin : IdentityUserLogin<int> { }
    public class ApplicationDbContext : IdentityDbContext<CartUser,CartRole,int,CartUserLogin,CartUserRole,CartUserClaim>
    {
        public ApplicationDbContext()
            : base("EFDbContext")
        {
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartUser>().ToTable("Customer").Property(p => p.Id).HasColumnName("CustomerID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CartUserRole>().ToTable("CartUserRole").Property(p => p.RoleId).HasColumnName("CartRoleID");
            modelBuilder.Entity<CartUserRole>().ToTable("CartUserRole").Property(p => p.UserId).HasColumnName("CustomerID");
            modelBuilder.Entity<CartUserLogin>().ToTable("CartUserLogin").Property(p => p.UserId).HasColumnName("CustomerID");
            modelBuilder.Entity<CartUserClaim>().ToTable("CartUserClaim").Property(p => p.Id).HasColumnName("CartUserClaimID");
            modelBuilder.Entity<CartUserClaim>().ToTable("CartUserClaim").Property(p => p.UserId).HasColumnName("CustomerID");
            modelBuilder.Entity<CartRole>().ToTable("CartRole").Property(p => p.Id).HasColumnName("CartRoleID");

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}