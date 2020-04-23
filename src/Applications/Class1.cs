using Applications.Interfaces;
using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applications
{
    public class ApplicatonsService : IApplicationsService
    {
        public Task<List<Client>> GetApplicationsAsync()
        {
            return Task.FromResult(new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".ToSha256()) },
                    AllowedScopes = { "api1" }
                }
            });
        }
    }
}
