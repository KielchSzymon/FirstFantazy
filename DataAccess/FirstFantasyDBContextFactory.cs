using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DataAcces
{
    public class FirstFantasyDBContextFactory : IDesignTimeDbContextFactory<FirstFantasyDBContext>
    {
        public FirstFantasyDBContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            var optionsBuilder = new DbContextOptionsBuilder<FirstFantasyDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FirstFantasyDBConnection"));

            return new FirstFantasyDBContext(optionsBuilder.Options);
        }
    }
}
