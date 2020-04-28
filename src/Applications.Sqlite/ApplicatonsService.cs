using System.Linq;
using Applications.Interfaces;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System;
using IdentityServer4.Models;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using IdentityModel;

namespace Applications.Sqlite
{
    public class ApplicatonsService : IApplicationsService
    {
        private readonly ConfigurationDbContext is4Context;

        public ApplicatonsService(ConfigurationDbContext is4Context)
        {
            this.is4Context = is4Context;
        }

        public Task<Client> CreateApplicationAsync(Client client)
        {
            if (string.IsNullOrEmpty(client.ClientName))
            {
                throw new Exception("Client name is missing!");
            }

            var clientSecret = CryptoRandom.CreateUniqueId();
            var secrets = new Collection<Secret>
            {
                new Secret(clientSecret.Sha256())
            };
            client.ClientId = CryptoRandom.CreateUniqueId();
            client.ClientSecrets = secrets;
            client.Properties = new Dictionary<string, string> {
                { "client_secret", clientSecret }
            };

            this.is4Context.Clients.Add(client.ToEntity());
            return Task.FromResult(client);
        }

        public Task<List<Client>> GetApplicationsAsync()
        {
            return Task.FromResult(
                is4Context.Clients
                .Select(c => c.ToModel())
                .ToList()
            );
        }

        public Task<Client> GetApplicationsByIdAsync(string clientId)
        {
            var client = is4Context.Clients
                .Where(c => c.ClientId.Equals(clientId))
                .FirstOrDefault();
            return Task.FromResult(client.ToModel());
        }
    }
}
