using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data;

namespace LogicLayer.DAO
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProjectModel(ProjectsDTO projectDTO)
        {
            Id = projectDTO.Id;
            Name = projectDTO.ProjectName;
        }
    }
}
