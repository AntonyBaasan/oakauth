using AutoMapper;
using IdentityServer4.Models;

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
