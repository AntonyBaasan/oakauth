using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using OakAuth.Interfaces.Applications;
using OakAuth.Models.Applications;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController: ControllerBase
    {
        private readonly IApplicationsService _applicationsService;

        public ApplicationsController(IApplicationsService applicationsService)
        {
            this._applicationsService = applicationsService;
        }

        [HttpPost]
        public async Task<Application> Create([FromBody] Application application)
        {
            var newApplication = await _applicationsService.CreateApplicationAsync(application);
            return newApplication;
        }

        public async Task<List<Application>> GetAll()
        {
            var applications = await _applicationsService.GetApplicationsAsync();
            return applications;
        }

        [HttpGet("{clientId}")]
        public async Task<Application> GetById(string clientId)
        {
            var application = await _applicationsService.GetApplicationsByIdAsync(clientId);
            return application;
        }

        [HttpPatch("{clientId}")]
        public async Task<IActionResult> Patch(string clientId, [FromBody] JsonPatchDocument<Application> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest(ModelState);
            }

            var application = await _applicationsService.GetApplicationsByIdAsync(clientId);
            patchDoc.ApplyTo(application);
            
            var updatedApplication = await _applicationsService.Update(clientId, application);
            return Ok(updatedApplication);
        }
    }
}