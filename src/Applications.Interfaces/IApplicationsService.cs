﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applications.Interfaces
{
    public interface IApplicationsService
    {
        Task<Application> CreateApplicationAsync(Application application);
        Task<List<Application>> GetApplicationsAsync();
        Task<Application> GetApplicationsByIdAsync(string clientId);
    }
}
