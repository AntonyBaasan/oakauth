using AutoMapper;
using IdentityServer4.Models;
using OakAuth.Interfaces.Applications;

namespace Applications.Interfaces.Automapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Client, Application>();
            CreateMap<Application, Client>();
        }
    }
}
