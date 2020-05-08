using IdentityModel;
using IdentityServer4.Models;
using OakAuth.Interfaces.Applications;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OakAuth.Service.Utility
{
    public class ApplicationModelBuilder
    {
        public Application CreateApplication(string clientName, ApplicationType applicationType) {
            Application application = new Application { ClientName = clientName };
            var clientSecret = CryptoRandom.CreateUniqueId();
            application.ClientId = CryptoRandom.CreateUniqueId();
            application.ClientSecrets = new Collection<Secret> { new Secret(clientSecret.Sha256()) };
            application.Properties = new Dictionary<string, string> {
                { "client_secret",  clientSecret}
            };

            return application;
        }
    }
}
