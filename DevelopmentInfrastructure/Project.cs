using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class Project
    {
        public Project()
        {
            Module = new HashSet<Module>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DatabaseEngine { get; set; }
        public string Frontend { get; set; }
        public string Backend { get; set; }
        public int TeamId { get; set; }
        public int ClientId { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public AuthUser Client { get; set; }
        public Team Team { get; set; }
        public ICollection<Module> Module { get; set; }
    }
}
