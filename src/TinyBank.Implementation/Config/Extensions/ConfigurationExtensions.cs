using Microsoft.Extensions.Configuration;

namespace TinyBank.Implementation.Config.Extensions
{
    public static class ConfigurationExtensions
    {
        public static AppConfig ReadAppConfiguration(this IConfiguration @this)
        {
            var connectionString = @this.GetConnectionString("TinyBankDb");

            return new AppConfig()
            {
                TinyBankDbConnectionString = connectionString,
            };
        }
    }
}
