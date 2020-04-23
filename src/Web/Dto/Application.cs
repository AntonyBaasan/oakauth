using IdentityServer4.Models;
using System.Collections.Generic;

namespace Web.Dto
{
    public class Application
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public ICollection<Secret> ClientSecrets { get; set; }
    }
}