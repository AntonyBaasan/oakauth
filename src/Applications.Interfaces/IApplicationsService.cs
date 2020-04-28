using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Applications.Interfaces
{
    public interface IApplicationsService
    {
        Task<Client> CreateApplicationAsync(Client client);
        Task<List<Client>> GetApplicationsAsync();
        Task<Client> GetApplicationsByIdAsync(string clientId);
    }
}
