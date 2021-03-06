﻿using System.Collections.Generic;
using IdentityServer4.Models;

namespace OakAuth.Models.Applications
{
    public class Application
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public ICollection<Secret> ClientSecrets { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public ICollection<string> AllowedScopes { get; set; }
    }
}
