using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace OakAuth.IntegrationTests.Controller
{
    public class ApplicationControllerIntegrationTests : BaseIntegrationTests
    {
        public ApplicationControllerIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Get_Should_Return_All_Applications() {
            var response = await _client.GetAsync("/applications");

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
