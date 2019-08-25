using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class AuthView
    {
        public AuthView()
        {
            AuthRoleView = new HashSet<AuthRoleView>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<AuthRoleView> AuthRoleView { get; set; }
    }
}
