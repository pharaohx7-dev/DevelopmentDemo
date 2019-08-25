using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class Team
    {
        public Team()
        {
            Project = new HashSet<Project>();
            Sprint = new HashSet<Sprint>();
            TeamMember = new HashSet<TeamMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public bool? IsActive { get; set; }

        public AuthCompany Company { get; set; }
        public ICollection<Project> Project { get; set; }
        public ICollection<Sprint> Sprint { get; set; }
        public ICollection<TeamMember> TeamMember { get; set; }
    }
}
