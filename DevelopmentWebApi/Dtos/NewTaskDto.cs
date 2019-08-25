using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentWebApi.Desarrollo.Dtos
{
    public class NewTaskDto
    {
        public int SprintTrackId { get; set; }
        public string Name { get; set; }
        public int TaskTypeId { get; set; }
    }
}
