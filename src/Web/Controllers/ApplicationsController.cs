using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Applications.Interfaces;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController
    {
        private readonly IApplicationsService applicationsService;

        public ApplicationsController(IApplicationsService applicationsService)
        {
            this.applicationsService = applicationsService;
        }

        [HttpPost]
        public async Task<Application> Create([FromBody] Application application) 
        {
            var newApplication = await applicationsService.CreateApplicationAsync(application);
            return newApplication;
        }

        public async Task<List<Application>> GetAll()
        {
            var applications = await applicationsService.GetApplicationsAsync();
            return applications;
        }

        [HttpGet("{clientId}")]
        public async Task<Application> GetById(string clientId)
        {
            var application = await applicationsService.GetApplicationsByIdAsync(clientId);
            return application;
        }
    }
}
