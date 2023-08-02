using SierraTakeHome.Core.Data;

namespace SierraTakeHome.Core.Test.DataBase
{
    public class DataContextTest
    {
        [Fact]
        public void CreateDataContextWithConnectionStringFromAppSettings()
        {
            var dataContextFactory = new DesignTimeDbContextFactory();

            var dbContext = dataContextFactory.CreateDbContext(null);

            
        }
    }
}