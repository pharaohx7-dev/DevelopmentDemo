using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class TaskType
    {
        public TaskType()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
