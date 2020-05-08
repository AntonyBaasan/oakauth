using System.Linq;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System;
using System.Collections.ObjectModel;
using IdentityModel;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using OakAuth.Interfaces.Applications;

namespace OakAuth.Service
{
    public class ApplicatonsService : IApplicationsService
    {
        private readonly ConfigurationDbContext is4Context;
        private readonly IMapper mapper;

        public ApplicatonsService(ConfigurationDbContext is4Context, IMapper mapper)
        {
            this.is4Context = is4Context;
            this.mapper = mapper;
        }

        public async Task<Application> CreateApplicationAsync(Application application)
        {
            if (string.IsNullOrEmpty(application.ClientName))
            {
                throw new Exception("Client name is missing!");
            }

            var clientSecret = CryptoRandom.CreateUniqueId();
            application.ClientId = CryptoRandom.CreateUniqueId();
            application.ClientSecrets = new Collection<Secret> { new Secret(clientSecret.Sha256()) };
            application.Properties = new Dictionary<string, string> {
                { "client_secret",  clientSecret}
            };

            var client = mapper.Map<Application, Client>(application);
            this.is4Context.Clients.Add(client.ToEntity());
            int count = await this.is4Context.SaveChangesAsync();
            return application;
        }

        public Task<List<Application>> GetApplicationsAsync()
        {
            return Task.FromResult(
                is4Context.Clients
                .Select(c => mapper.Map<Client, Application>(c.ToModel()))
                .ToList()
            );
        }

        public Task<Application> GetApplicationsByIdAsync(string clientId)
        {
            var client = is4Context.Clients
                .Where(c => c.ClientId.Equals(clientId))
                .Include(c => c.Properties)
                .FirstOrDefault();
            return Task.FromResult(mapper.Map<Client, Application>(client.ToModel()));
        }
    }
}
