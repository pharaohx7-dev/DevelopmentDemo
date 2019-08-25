using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class Sprint
    {
        public Sprint()
        {
            SprintDetail = new HashSet<SprintDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Team Team { get; set; }
        public ICollection<SprintDetail> SprintDetail { get; set; }
    }
}
