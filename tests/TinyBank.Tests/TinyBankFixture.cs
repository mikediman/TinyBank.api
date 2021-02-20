using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TinyBank.Implementation.ServiceExtensions;

namespace TinyBank.Tests
{
    public class TinyBankFixture : IDisposable
    {
        public IServiceScope Scope { get; private set; }

        public TinyBankFixture()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
                .AddJsonFile("appsettings.json", false)
                .Build();
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAppServices(config);

            Scope = serviceCollection
                .BuildServiceProvider()
                .CreateScope();
        }

        public void Dispose()
        {
            Scope.Dispose();
        }
    }
}
