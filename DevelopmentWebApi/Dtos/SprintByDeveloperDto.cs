using System;
using System.Collections.Generic;

namespace DevelopmentWebApi.Desarrollo.Dtos
{
    public class SprintByDeveloperDetailDto
    {
        public int SprintDetailId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public string RequirementName { get; set; }
        public string RequirementDescription { get; set; }
        public decimal RequirementEstimatedHours { get; set; }
        public decimal RequirementWorkedHours { get; set; }
        public List<PendingTaskByDeveloperDto> Tasks { get; set; }
    }

    public class PendingTaskByDeveloperDto
    {
        public int SprintTrackId { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
    }
}
