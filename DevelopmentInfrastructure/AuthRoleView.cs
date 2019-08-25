using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class AuthRoleView
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ViewId { get; set; }
        public bool? IsActive { get; set; }

        public AuthRole Role { get; set; }
        public AuthView View { get; set; }
    }
}
