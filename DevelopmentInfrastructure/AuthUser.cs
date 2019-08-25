using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class AuthUser
    {
        public AuthUser()
        {
            Project = new HashSet<Project>();
            SprintDetail = new HashSet<SprintDetail>();
            TeamMemberDeveloper = new HashSet<TeamMember>();
            TeamMemberTeamLeader = new HashSet<TeamMember>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        public bool? IsActive { get; set; }

        public AuthCompany Company { get; set; }
        public AuthRole Role { get; set; }
        public ICollection<Project> Project { get; set; }
        public ICollection<SprintDetail> SprintDetail { get; set; }
        public ICollection<TeamMember> TeamMemberDeveloper { get; set; }
        public ICollection<TeamMember> TeamMemberTeamLeader { get; set; }
    }
}
