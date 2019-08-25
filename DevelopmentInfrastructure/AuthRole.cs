using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class AuthRole
    {
        public AuthRole()
        {
            AuthRoleView = new HashSet<AuthRoleView>();
            AuthUser = new HashSet<AuthUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<AuthRoleView> AuthRoleView { get; set; }
        public ICollection<AuthUser> AuthUser { get; set; }
    }
}
