using AutoMapper;
using IdentityServer4.Models;
using OakAuth.Interfaces.Applications;
using System.Collections.Generic;

namespace Applications.Service.Automapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Client, Application>();
            CreateMap<Application, Client>()
                .ForMember(dest => dest.AllowedGrantTypes,
                           opt => opt.MapFrom(src => MapAllowedGrantTypes(src.ApplicationType)))
                .ForMember(dest => dest.RequirePkce,
                           opt => opt.MapFrom(src => IsPkceRequired(src.ApplicationType)))
                ;
        }

        private bool IsPkceRequired(ApplicationType applicationType)
        {

            switch (applicationType)
            {
                case ApplicationType.Native:
                case ApplicationType.SinglePageApplication:
                    return true;
                case ApplicationType.RegularWeb:
                case ApplicationType.MachineToMachine:
                    return false;
            }
            return false;
        }

        private ICollection<string> MapAllowedGrantTypes(ApplicationType applicationType)
        {
            switch (applicationType)
            {
                case ApplicationType.Native:
                case ApplicationType.SinglePageApplication:
                case ApplicationType.RegularWeb:
                    return GrantTypes.Code;
                case ApplicationType.MachineToMachine:
                    return GrantTypes.ClientCredentials;
            }
            return null;
        }
        //public static ICollection<string> Implicit { get; }
        //public static ICollection<string> ImplicitAndClientCredentials { get; }
        //public static ICollection<string> Code { get; }
        //public static ICollection<string> CodeAndClientCredentials { get; }
        //public static ICollection<string> Hybrid { get; }
        //public static ICollection<string> HybridAndClientCredentials { get; }
        //public static ICollection<string> ClientCredentials { get; }
        //public static ICollection<string> ResourceOwnerPassword { get; }
        //public static ICollection<string> ResourceOwnerPasswordAndClientCredentials { get; }
        //public static ICollection<string> DeviceFlow { get; }
    }
}
