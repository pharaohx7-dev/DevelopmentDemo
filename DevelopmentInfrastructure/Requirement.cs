using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class Requirement
    {
        public Requirement()
        {
            SprintDetail = new HashSet<SprintDetail>();
        }

        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal EstimatedHours { get; set; }
        public decimal WorkedHours { get; set; }

        public Module Module { get; set; }
        public ICollection<SprintDetail> SprintDetail { get; set; }
    }
}
