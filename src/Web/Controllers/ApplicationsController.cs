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

        [HttpPost]
        public async Task<ApplicationDto> Create([FromBody] ApplicationDto applicationDto) 
        {
            var client = await applicationsService.CreateApplicationAsync(new Client { 
                ClientName = applicationDto.ClientName
            });
            var application = mapper.Map<Client, ApplicationDto>(client);
            return application;
        }

        public async Task<List<ApplicationDto>> GetAll()
        {
            var clients = await applicationsService.GetApplicationsAsync();
            List<ApplicationDto> applications = mapper.Map<List<Client>, List<ApplicationDto>>(clients);
            return applications;
        }

        [HttpGet("{clientId}")]
        public async Task<ApplicationDto> GetById(string clientId)
        {
            var client = await applicationsService.GetApplicationsByIdAsync(clientId);
            var application = mapper.Map<Client, ApplicationDto>(client);
            return application;
        }
    }
}
