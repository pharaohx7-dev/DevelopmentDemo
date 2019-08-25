using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class Module
    {
        public Module()
        {
            Requirement = new HashSet<Requirement>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Project Project { get; set; }
        public ICollection<Requirement> Requirement { get; set; }
    }
}
