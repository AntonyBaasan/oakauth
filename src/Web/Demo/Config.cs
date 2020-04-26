using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;

namespace Web.Demo
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetResources()
        {
            var oakauthProfile = new IdentityResource
            (
                name: "aokauth.profile",
                displayName: "OakAuth Profile",
                claimTypes: new[] { "name", "email", "status" }
            );
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                oakauthProfile
            };
        }
        public static IEnumerable<ApiResource> Api =>
            new List<ApiResource>
            {
                new ApiResource("api1", "Test Api"),
                new ApiResource {
                    Name = "api2"           ,
                    Description = "demo api2",
                    DisplayName = "api2",
                    Enabled = true, // default is true
                    Properties  = new Dictionary<string, string>(),
                    ApiSecrets = { new Secret("password".Sha256()) },
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email },
                    Scopes = {
                        new Scope { Name = "api2.fullaccess", DisplayName = "Full access to API 2" },
                        new Scope { Name = "api2.read_only", DisplayName = "Read only access to API 2" },
                    }
                }
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
                },
                // server to server
                new Client
                {
                    ClientId = "service.client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api1" }
                },
                // browser based client JavaScript app
                new Client
                {
                    ClientId = "js.client",
                    ClientName  = "JavaScript client",
                    ClientUri  = "https://clienturl.com",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    AllowedScopes = { "api1" }
                }
            };

    }
}
