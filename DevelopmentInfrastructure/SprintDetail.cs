using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class SprintDetail
    {
        public SprintDetail()
        {
            SprintTrack = new HashSet<SprintTrack>();
        }

        public int Id { get; set; }
        public int SprintId { get; set; }
        public int RequirementId { get; set; }
        public int DeveloperId { get; set; }

        public AuthUser Developer { get; set; }
        public Requirement Requirement { get; set; }
        public Sprint Sprint { get; set; }
        public ICollection<SprintTrack> SprintTrack { get; set; }
    }
}
