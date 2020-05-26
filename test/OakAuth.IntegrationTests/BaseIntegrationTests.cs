using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Web;
using Xunit;

namespace OakAuth.IntegrationTests
{
    public abstract class BaseIntegrationTests: IClassFixture<CustomWebApplicationFactory>
    {
        protected readonly CustomWebApplicationFactory _factory;
        protected readonly HttpClient _client;
        protected readonly IConfigurationRoot _configuration;

        public BaseIntegrationTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("integrationsettings.json")
                .Build();
        }
    }
}
