using Microsoft.EntityFrameworkCore;
using SierraTakeHome.Core.Models.Orders;
using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Product> Products => Set<Product>();
    }
}