using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class AuthCompany
    {
        public AuthCompany()
        {
            AuthUser = new HashSet<AuthUser>();
            Team = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<AuthUser> AuthUser { get; set; }
        public ICollection<Team> Team { get; set; }
    }
}
