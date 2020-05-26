using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Xunit;

namespace OakAuth.IntegrationTests
{
    public abstract class BaseIntegrationTests: IClassFixture<CustomWEbApplicationFactory>
    {
        protected readonly CustomWEbApplicationFactory _factory;
        protected readonly HttpClient _client;
        protected readonly IConfigurationRoot _configuration;

        public BaseIntegrationTests(CustomWEbApplicationFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("integrationsettings.json")
                .Build();
        }
    }
}
