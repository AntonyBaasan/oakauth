using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Applications.Interfaces
{
    public interface IApplicationsService
    {
        Task<List<Client>> GetApplicationsAsync();
    }
}
