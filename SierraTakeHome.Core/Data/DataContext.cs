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

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("TB_PRODUCT");
            modelBuilder.Entity<Customer>().ToTable("TB_CUSTOMER");
            modelBuilder.Entity<Order>().ToTable("TB_ORDER");
        }
    }
}