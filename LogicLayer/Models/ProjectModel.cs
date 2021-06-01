using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data;

namespace LogicLayer.DAO
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public ProjectModel(ProjectsDTO projectDto)
        {
            ProjectId = projectDto.ProjectId;
            Name = projectDto.ProjectName;
        }
    }
}
