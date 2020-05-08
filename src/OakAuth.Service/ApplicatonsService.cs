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
using Microsoft.AspNetCore.Builder;
using OakAuth.Service.Utility;

namespace OakAuth.Service
{
    public class ApplicatonsService : IApplicationsService
    {
        private readonly ConfigurationDbContext is4Context;
        private readonly IMapper mapper;
        private readonly ApplicationModelBuilder builder;

        public ApplicatonsService(ConfigurationDbContext is4Context, IMapper mapper)
        {
            this.is4Context = is4Context;
            this.mapper = mapper;
            builder = new ApplicationModelBuilder();
        }

        public async Task<Application> CreateApplicationAsync(Application application)
        {
            if (string.IsNullOrEmpty(application.ClientName))
            {
                throw new Exception("Client name is missing!");
            }

            var fullApplication = builder.CreateApplication(application.ClientName, application.ApplicationType);
            var client = mapper.Map<Application, Client>(fullApplication);
            is4Context.Clients.Add(client.ToEntity());
            int count = await is4Context.SaveChangesAsync();
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
