using System.Collections.Generic;
using System.Threading.Tasks;
using OakAuth.Models.Applications;

namespace OakAuth.Interfaces.Applications
{
    public interface IApplicationsService
    {
        Task<Application> CreateApplicationAsync(Application application);
        Task<List<Application>> GetApplicationsAsync();
        Task<Application> GetApplicationsByIdAsync(string clientId);
        Task<Application> Update(string clientId, Application application);
    }
}
