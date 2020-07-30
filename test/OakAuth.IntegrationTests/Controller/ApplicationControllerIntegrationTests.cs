using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OakAuth.Interfaces.Applications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OakAuth.Models.Applications;
using Xunit;

namespace OakAuth.IntegrationTests.Controller
{
    public class ApplicationControllerIntegrationTests : BaseIntegrationTests
    {
        public ApplicationControllerIntegrationTests(CustomWEbApplicationFactory factory ) : base(factory)
        {
            SetupData();
        }

        private void SetupData() {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var is4Context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            is4Context.Clients.Add(new IdentityServer4.EntityFramework.Entities.Client());
            is4Context.SaveChanges();
        }

        [Fact]
        public async Task Get_Should_Return_All_Applications()
        {
            var response = await _client.GetAsync("/api/applications");

            var content = await response.Content.ReadAsStringAsync();
            var applications = JsonConvert.DeserializeObject<List<Application>>(content);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Single(applications);
        }
    }
}
