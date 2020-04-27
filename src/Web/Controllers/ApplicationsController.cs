using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Applications.Interfaces;
using System.Threading.Tasks;
using Web.Dto;
using AutoMapper;
using IdentityServer4.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController
    {
        private readonly IApplicationsService applicationsService;
        private readonly IMapper mapper;

        public ApplicationsController(IApplicationsService applicationsService, IMapper mapper)
        {
            this.applicationsService = applicationsService;
            this.mapper = mapper;
        }

        public async Task<List<Application>> GetAll()
        {
            var clients = await applicationsService.GetApplicationsAsync();
            List<Application> applications = mapper.Map<List<Client>, List<Application>>(clients);
            return applications;
        }

        [HttpGet("{clientId}")]
        public async Task<Application> GetById(string clientId)
        {
            var client = await applicationsService.GetApplicationsByIdAsync(clientId);
            var application = mapper.Map<Client, Application>(client);
            return application;
        }
    }
}
