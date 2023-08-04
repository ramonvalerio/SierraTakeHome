using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SierraTakeHome.Core.Domain.Customers;
using SierraTakeHome.Core.Domain.Orders;
using SierraTakeHome.Core.Domain.Products;
using SierraTakeHome.Core.Domain.Users;

namespace SierraTakeHome.Core.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            CreateDatabaseIfNotExists();
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

        public void CreateDatabaseIfNotExists()
        {
            try
            {
                if (!Database.GetService<IRelationalDatabaseCreator>().Exists())
                {
                    Database.EnsureCreated();
                    ExecuteSqlScript("CreateOrder.sql");
                    ExecuteSqlScript("InitData.sql");

                    Database.ExecuteSqlRawAsync("EXEC InitData");
                }
            }
            catch (Exception)
            {
                throw new Exception("Database Server not found.");
            }
        }

        public void ExecuteSqlScript(string fileName)
        {
            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts", fileName);
            string sqlScript = File.ReadAllText(scriptPath);
            Database.ExecuteSqlRaw(sqlScript);
        }
    }
}