using System;
using System.Collections.Generic;

namespace DevelopmentInfrastructure
{
    public partial class Task
    {
        public int Id { get; set; }
        public int SprintTrackId { get; set; }
        public string Name { get; set; }
        public string MediaServerPath { get; set; }
        public int TaskTypeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool IsCompleted { get; set; }

        public SprintTrack SprintTrack { get; set; }
        public TaskType TaskType { get; set; }
    }
}
