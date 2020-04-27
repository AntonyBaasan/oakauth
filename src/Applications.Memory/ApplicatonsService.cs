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
            return Task.FromResult(is4Context.Clients
                    .Include(c => c.ClientSecrets)
                    .Select(c => c.ToModel()).ToList());
        }
    }
}
