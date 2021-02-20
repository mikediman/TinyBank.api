using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using TinyBank.Implementation.Config;
using TinyBank.Implementation.Config.Extensions;
using TinyBank.Implementation.Database;
using TinyBank.Interfaces;

namespace TinyBank.Implementation.ServiceExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddSingleton<AppConfig>(configuration.ReadAppConfiguration());

            @this.AddDbContext<TinyBankDbContext>(
                (serviceProvider, optionsBuilder)=> {
                    var appConfig = serviceProvider.GetRequiredService<AppConfig>();
                    optionsBuilder.UseSqlServer(appConfig.TinyBankDbConnectionString);
                });

            @this.AddScoped<IUserService, UserService>();
        }
    }
}
