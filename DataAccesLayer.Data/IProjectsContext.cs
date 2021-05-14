using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Data
{
    public interface IProjectsContext
    {


        List<ProjectsDTO> GetAllProjects();

        ProjectsDTO GetProjectById(int id);



    }
}
