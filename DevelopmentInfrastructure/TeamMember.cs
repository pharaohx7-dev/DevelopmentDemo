using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class TeamMember
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int TeamLeaderId { get; set; }
        public int DeveloperId { get; set; }
        public bool? IsActive { get; set; }

        public AuthUser Developer { get; set; }
        public Team Team { get; set; }
        public AuthUser TeamLeader { get; set; }
    }
}
