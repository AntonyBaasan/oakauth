using AutoMapper;
using IdentityServer4.Models;
using OakAuth.Interfaces.Applications;
using System;
using System.Security.Cryptography;

namespace Applications.Interfaces.Automapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Client, Application>();
            CreateMap<Application, Client>()
                .ForMember(dest=>dest.AllowedGrantTypes,
                           opt => opt.MapFrom(src => MapAllowedGrantTypes(src.ApplicationType)));
        }

        private object MapAllowedGrantTypes(ApplicationType applicationType)
        {
            switch (applicationType) {
                case ApplicationType.Native:
                    break;
                case ApplicationType.SinglePageApplication:
                    break;
                case ApplicationType.RegularWeb:
                    break;
                case ApplicationType.MachineToMachine:
                    return GrantType.ClientCredentials;
            }
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
