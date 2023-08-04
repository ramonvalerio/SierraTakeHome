using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SierraTakeHome.Core.Data;

namespace SierraTakeHome.Core.Test.DataBase
{
    public class DataContextTest
    {
        private readonly DataContext _context;

        public DataContextTest()
        {
            var builder = WebApplication.CreateBuilder();
            var connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();
            var serviceScope = app.Services.CreateScope();
            var services = serviceScope.ServiceProvider;
            _context = services.GetRequiredService<DataContext>();   
        }

        [Fact]
        public void TestDataBaseConnection_With_Not_DatabaseServer()
        {
            try
            {
                _context.CreateDatabaseIfNotExists();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
            
        [Fact]
        public void ExecuteSqlScript()
        {
            _context.ExecuteSqlScript("CreateOrder.sql");
            _context.ExecuteSqlScript("InitData.sql");
        }
    }
}