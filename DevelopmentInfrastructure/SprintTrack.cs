using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class SprintTrack
    {
        public SprintTrack()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int SprintDetailId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public SprintDetail SprintDetail { get; set; }
        public ICollection<Task> Task { get; set; }
    }
}
