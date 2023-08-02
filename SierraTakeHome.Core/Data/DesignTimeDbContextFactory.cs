using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SierraTakeHome.Core.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var configurationPath = string.Empty;

            // Loop to search for the directory containing the project with appsettings.json
            while (currentDirectory != null)
            {
                var targetPath = Path.Combine(currentDirectory, "SierraTakeHome.API");
                if (Directory.Exists(targetPath))
                {
                    configurationPath = targetPath;
                    break;
                }
                var parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
                if (parentDirectory == null || parentDirectory == currentDirectory)
                {
                    break; // Stop the loop if it reaches the root directory
                }
                currentDirectory = parentDirectory;
            }

            if (string.IsNullOrEmpty(configurationPath))
            {
                throw new InvalidOperationException("Path to appsettings.json not found.");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(configurationPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
