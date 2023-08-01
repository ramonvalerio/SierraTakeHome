using Microsoft.EntityFrameworkCore;
using SierraTakeHome.Core.Models.Customers;
using SierraTakeHome.Core.Models.Orders;
using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Order> Orders { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("TB_PRODUCT");
            modelBuilder.Entity<Customer>().ToTable("TB_CUSTOMER");
            modelBuilder.Entity<Order>().ToTable("TB_ORDER");
        }
    }
}