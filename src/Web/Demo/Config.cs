using IdentityServer4.Models;
using System.Collections.Generic;

namespace Web.Demo
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Api =>
            new List<ApiResource>
            {
                new ApiResource("api1", "Test Api")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api1" }
                }
            };

    }
}
