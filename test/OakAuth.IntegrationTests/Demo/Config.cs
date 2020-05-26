using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;

namespace OakAuth.IntegrationTests.Demo
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

        public static IEnumerable<ApiResource> Apis =>
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
                    ClientId = "xsaddfdasdfe4w111",
                    ClientName = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret".Sha256(), "Client's secret")
                    },
                    AllowedScopes = { "api1" }
                },
                // server to server
                new Client
                {
                    ClientId = "xsaddfdasdfe4w222",
                    ClientName = "service.client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret".Sha256()),
                    },
                    AllowedScopes = { "api1" }
                },
                // browser based client JavaScript app (implicit flow)
                new Client
                {
                    ClientId = "xsaddfdasdfe4w333",
                    ClientName  = "JavaScript client",
                    ClientUri  = "https://clienturl.com",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:7017/index.html" },
                    PostLogoutRedirectUris = { "http://localhost:7017/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:7017" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1", "api2.read_only"
                    }
                },
                new Client
                {
                    ClientName  = "MVC client",
                    ClientId = "mvc",
                    ClientUri  = "https://clienturl.com",

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets = { new Secret("password".Sha256()) },

                    RedirectUris =           { "http://localhost:7017/index.html" },
                    PostLogoutRedirectUris = { "http://localhost:7017/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:7017" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1", "api2.read_only"
                    }
                },
                new Client
                {
                    ClientName  = "OIDC Debugger 1",
                    ClientId = "oidcdebugger1",
                    ClientUri  = "https://oidcdebugger.com/",

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets = { new Secret("password".Sha256()) },

                    RedirectUris =           { "https://oidcdebugger.com/debug" },
                    PostLogoutRedirectUris = { "https://oidcdebugger.com/debug" },
                    AllowedCorsOrigins =     { "https://oidcdebugger.com" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1", "api2.read_only"
                    }
                },
                new Client
                {
                    ClientName  = "OIDC Debugger 2",
                    ClientId = "oidcdebugger2",
                    ClientUri  = "https://oidcdebugger.com/",

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets = { new Secret("password".Sha256()) },
                    RequirePkce = true,

                    RedirectUris =           { "https://oidcdebugger.com/debug" },
                    PostLogoutRedirectUris = { "https://oidcdebugger.com/debug" },
                    AllowedCorsOrigins =     { "https://oidcdebugger.com" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1", "api2.read_only"
                    }
                }
            };

    }
}
