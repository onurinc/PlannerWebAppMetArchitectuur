using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
   public class ProjectModel
    {
        public ProjectModel(int _id, string projectName)
        {
            Id = _id;
            ProjectName = projectName;
        }

        public ProjectModel()
        {
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
    }
}
