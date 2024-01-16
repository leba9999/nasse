using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageHandler.Data
{
    public class ImageContextFactory : IDesignTimeDbContextFactory<ImageDbContext>
    {
        public ImageDbContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<ImageDbContext>();
            ServerVersion version = ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]);

            optionsBuilder
                .UseMySql(configuration["ConnectionStrings:DefaultConnection"], version)
                .LogTo(Console.WriteLine, LogLevel.Debug)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();

            return new ImageDbContext(optionsBuilder.Options);
        }
    }
}
