using Applications.Interfaces;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using System.Linq;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Applications.Memory
{
    public class ApplicatonsService : IApplicationsService
    {
        private readonly ConfigurationDbContext is4Context;

        public ApplicatonsService(ConfigurationDbContext is4Context)
        {
            this.is4Context = is4Context;
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
