using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data;

namespace LogicLayer.DAO
{
    public class ProjectDAO
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ProjectDAO(ProjectsDTO registerDTO)
        {
            Id = registerDTO.Id;
            Name = registerDTO.ProjectName;

        }
    }
}
