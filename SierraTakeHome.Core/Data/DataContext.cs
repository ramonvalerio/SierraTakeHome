using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SierraTakeHome.Core.Models.Customers;
using SierraTakeHome.Core.Models.Orders;
using SierraTakeHome.Core.Models.Products;
using SierraTakeHome.Core.Models.Users;

namespace SierraTakeHome.Core.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Order> Orders { get; private set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().ToTable("TB_PRODUCT");
            builder.Entity<Customer>().ToTable("TB_CUSTOMER");
            builder.Entity<Order>().ToTable("TB_ORDER");
            builder.Entity<ApplicationUser>().ToTable("TB_USER");
        }
    }
}