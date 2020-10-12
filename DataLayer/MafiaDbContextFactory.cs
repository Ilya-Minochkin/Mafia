using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace DataLayer
{
    /// <summary>
    /// For Migrations
    /// </summary>
    public class MafiaDbContextFactory : IDesignTimeDbContextFactory<MafiaDbContext>
    {
        public MafiaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MafiaDbContext>();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(builder.GetConnectionString("MafiaDatabase"), b => b.MigrationsAssembly("DataLayer"));
            return new MafiaDbContext(optionsBuilder.Options);
        }
    }
}
