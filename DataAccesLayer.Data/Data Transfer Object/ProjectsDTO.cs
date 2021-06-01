using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DataAccesLayer.Data
{
    public class ProjectsDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public ProjectsDTO()
        {

        }

        public ProjectsDTO(int projectId, string projectName)
        {
            ProjectId = projectId;
            ProjectName = projectName;
        }

    }
}
