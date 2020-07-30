using IdentityModel;
using IdentityServer4.Models;
using OakAuth.Interfaces.Applications;
using OakAuth.Models.Applications;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IdentityServer4;

namespace OakAuth.Service.Utility
{
    public class ApplicationModelBuilder
    {
        public Application CreateApplication(string clientName, ApplicationType applicationType)
        {
            var application = new Application {ClientName = clientName};
            var clientSecret = CryptoRandom.CreateUniqueId();
            application.ClientId = CryptoRandom.CreateUniqueId();
            application.ClientSecrets = new Collection<Secret> {new Secret(clientSecret.Sha256())};
            application.Properties = new Dictionary<string, string>
            {
                {"client_secret", clientSecret}
            };
            application.ApplicationType = applicationType;
            application.AllowedScopes = GetAllowedScopes(applicationType);

            return application;
        }

        private ICollection<string> GetAllowedScopes(ApplicationType applicationType)
        {
            switch (applicationType)
            {
                case ApplicationType.Native:
                case ApplicationType.SinglePageApplication:
                case ApplicationType.RegularWeb:
                    return new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    };
                case ApplicationType.MachineToMachine:
                    return new List<string>();
            }

            return new List<string>();
        }
        //new Client
        //{
        //    ClientName  = "OIDC Debugger",
        //    ClientId = "oidcdebugger",
        //    ClientUri  = "https://oidcdebugger.com/",

        //    AllowedGrantTypes = GrantTypes.Hybrid,
        //    AllowAccessTokensViaBrowser = true,
        //    ClientSecrets = { new Secret("password".Sha256()) },

        //    RedirectUris =           { "https://oidcdebugger.com/debug" },
        //    PostLogoutRedirectUris = { "https://oidcdebugger.com/debug" },
        //    AllowedCorsOrigins =     { "https://oidcdebugger.com" },

        //    AllowedScopes = {
        //        IdentityServerConstants.StandardScopes.OpenId,
        //        IdentityServerConstants.StandardScopes.Profile,
        //        IdentityServerConstants.StandardScopes.Email,
        //        "api1", "api2.read_only"
        //    }
        //}
    }
}