using FirstFantazy.Core;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using RepositoryCommon;

namespace FirstFantazy.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

           
            services.AddDbContext<FirstFantasyDBContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("FirstFantasyDBConnection")));

            services.AddScoped<IRepositoryLevelText, RepositoryLevelText>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            GameCore core = new GameCore(serviceProvider);

            core.StartCore();
           
        }
    }
}
