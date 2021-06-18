using System;
using DataAccesLayer.Data;

namespace LogicLayer.DAO
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        public ProjectModel(ProjectsDTO projectDto)
        {
            ProjectId = projectDto.ProjectId; 
            UserId = projectDto.UserId;
            ProjectName = projectDto.ProjectName;
            ProjectDescription = projectDto.ProjectDescription;
        }
    }
}
