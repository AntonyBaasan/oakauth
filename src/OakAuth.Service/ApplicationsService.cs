using System.Linq;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using OakAuth.Interfaces.Applications;
using OakAuth.Service.Utility;

namespace OakAuth.Service
{
    public class ApplicationsService : IApplicationsService
    {
        private readonly ConfigurationDbContext _is4Context;
        private readonly IMapper _mapper;
        private readonly ApplicationModelBuilder _builder;

        public ApplicationsService(ConfigurationDbContext is4Context, IMapper mapper)
        {
            this._is4Context = is4Context;
            this._mapper = mapper;
            _builder = new ApplicationModelBuilder();
        }

        public async Task<Application> CreateApplicationAsync(Application application)
        {
            if (string.IsNullOrEmpty(application.ClientName))
            {
                throw new Exception("Client name is missing!");
            }

            var fullApplication = _builder.CreateApplication(application.ClientName, application.ApplicationType);
            var client = _mapper.Map<Application, Client>(fullApplication);
            await _is4Context.Clients.AddAsync(client.ToEntity());
            var count = await _is4Context.SaveChangesAsync();
            return application;
        }

        public Task<List<Application>> GetApplicationsAsync()
        {
            return Task.FromResult(
                _is4Context.Clients
                .Select(c => _mapper.Map<Client, Application>(c.ToModel()))
                .ToList()
            );
        }

        public Task<Application> GetApplicationsByIdAsync(string clientId)
        {
            var client = _is4Context.Clients
                .Where(c => c.ClientId.Equals(clientId))
                .Include(c => c.Properties)
                .Include(c => c.AllowedScopes)
                .FirstOrDefault();
            return Task.FromResult(_mapper.Map<Client, Application>(client.ToModel()));
        }

        public async Task<Application> Update(string clientId, Application application)
        {
            var client = _mapper.Map<Application, Client>(application);
            var entity = _is4Context.Clients.FirstOrDefault(c => c.ClientId == clientId);
            if (entity == null)
            {
                throw new MissingMemberException("Can't find application!");
            }
            _is4Context.Entry(entity).CurrentValues.SetValues(client);
            await _is4Context.SaveChangesAsync();
            return application; 
        }
    }
}
