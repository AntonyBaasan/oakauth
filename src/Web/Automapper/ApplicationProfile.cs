using AutoMapper;
using IdentityServer4.Models;
using Web.Dto;

namespace Web.Automapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Client, ApplicationDto>();
        }
    }
}
